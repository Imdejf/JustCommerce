export default {
  props: {
    width: {
      required: false,
      default: '100%'
    },
    height: {
      required: false,
      default: 36
    },
    validation: {
      type: Object,
      required: false,
      default: null
    },
    messages: {
      type: Object,
      required: false,
      default: () => ({})
    },
    disabled: {
      type: Boolean,
      required: false,
      default: false
    },
    label: {
      type: String,
      required: false,
      default: null
    },
    placeHolder: {
      type: String,
      required: false,
      default: null
    },
    tooltip: {
      type: String,
      required: false,
      default: null
    },
    tooltipPlacement: {
      type: String,
      required: false,
      default: 'top'
    },
    lazy: {
      type: Boolean,
      required: false,
      default: true
    }
  },
  data: function () {
    return {
      errors: [],
      mode: 'text', // przyjmuje wartości 'password', 'email', 'tel', 'search', 'url', 'text',
      format: null,
      type: 'date',

      skipOnValueChanged: true,
      setUndefinedNextTime: false
    }
  },
  computed: {
    wrapperConfig: function () {
      // Wszystko co jest potrzebne w wrapperze do zmiany UI
      return {
        width: this.width,
        height: this.height,
        theme: this.thexme,
        disabled: this.disabled,
        validation: this.validation,
        errors: this.errors,
        label: this.label,
        tooltip: this.tooltip,
        tooltipPlacement: this.tooltipPlacement,
        hideLabel: !!this.hideLabel
      }
    },
    config: function () {
      // Wszystko, co jest wykorzystywane przez kontrolkę. Należy używać tego zamiast bezpośrednio propsów.
      return {
        value: this.value,
        width: this.width,
        height: this.height,
        placeHolder: this.placeHolder,
        readOnly: this.disabled,
        format: this.valueFormatter,
        min: this.min,
        max: this.max,

        // text input
        mode: this.mode,
        maxLength: this.maxLength,
        promptChar: this.promptChar,
        mask: this.mask,

        // number input
        spinButtons: this.spinButtons,
        spinStep: this.spinButtonsStep,

        // datetime input
        type: this.type,

        // checkbox
        text: this.placeHolder,

        // calendar
        showTodayButton: this.showFooter,

        // radio group
        options: this.options,
        layout: this.useHorizontalLayout ? 'horizontal' : 'vertical',

        itemHeight: this.itemHeight,

        // range slider
        step: this.step,
        valueTooltipEnabled: this.valueTooltipEnabled,
        valueTooltipPosition: this.valueTooltipPosition,
        valueTooltipShowMode: this.valueTooltipShowMode,
        valueLabelEnabled: this.valueLabelEnabled,
        valueLabelPosition: this.valueLabelPosition,
        valueMax: this.valueMax,
        valueMin: this.valueMin
      }
    },
    requiredValue: function () {
      if (this.validation && this.validation.$params && this.validation.$params.required) {
        const required = this.validation.$params.required

        if (required.type === 'required') {
          return 'always'
        }

        if (required.type === 'requiredIf' && required.prop) {
          return 'conditionally'
        }
      }
      return 'never'
    }
  },
  watch: {
    validation: {
      handler: function () {
        this.calculateErrors()
      },
      deep: true
    }
  },
  methods: {
    focus: function () {
      this.$refs.input.instance.focus()
    },

    onInput: function (event) {
      if (this.lazy) return

      if (this.throttle) {
        window.clearTimeout(this.timeout)
        this.timeout = setTimeout(() => {
          const value = this.$refs.input.instance.option('text')
          this.onValueChanged({ value: value })
        }, this.throttle)
      } else {
        const value = this.$refs.input.instance.option('text')
        this.onValueChanged({ value: value })
      }
    },
    onValueChanged: function (event) {
      this.$emit('update:value', event.value)
      this.$emit('changed', event.value)
      this.$nextTick(() => {
        if (this.validation) {
          this.validation.$touch()
        }
        this.calculateErrors()
      })
    },
    calculateErrors: function () {
      const data = {
        validation: this.validation,
        messages: this.messages,
        $t: this.$t,
        $i18n: this.$i18n,
        errors: null
      }
      this.calculateControlErrors(data)
      this.errors = data.errors
    },
    calculateControlErrors: function (control) {
      const utils = {}
      const errors = []
      if (control.validation && control.validation.$error) {
        const validators = Object.keys(control.validation.required.$params)
        for (let i = 0; i < validators.length; i++) {
          console.log(control.validation[validators[i]] !== false)
          if (control.validation.required.$response.value !== false) {
            if (validators[i] === '__error') {
              errors.push(control.validation.required.$params.__error.errFun())
            } else if (control.messages[validators[i]] && control.messages[validators[i]].translated) {
              errors.push(
                utils.format(
                  control.messages[validators[i]].translated,
                  control.validation.required.$params[validators[i]]
                )
              )
            } else {
              let resx
              if (control.messages[validators[i]]) {
                resx = 'validation.' + control.messages[validators[i]].resx
              } else {
                resx = 'validation.' + validators[i]
              }
              errors.push(control.$t(resx, control.validation.required.$params[validators[i]]))
            }
          }
        }
      }
      control.errors = errors
    }
  },
  mounted: function () {
    if (this.validation) {
      this.validation.$reset()
    }
  }
}
