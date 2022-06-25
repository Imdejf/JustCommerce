<template>
  <input-wrapper ref="wrapper" :config="wrapperConfig" :class="'rs-dx-input-wrapper--number'">
    <dx-input
      ref="input"
      :value="config.value"
      @valueChanged="onValueChanged"
      @input="onInput"
      :width="config.width"
      :height="config.height"

      :placeholder="config.placeHolder"
      :readOnly="config.readOnly"

      :min="config.min"
      :max="config.max"

      :showSpinButtons="spinButtons"
      :step="spinStep"
      :showClearButton="allowNull"

      :format="config.format"
      :class="[
        { 'rs-dx-align-end' : this.textAlign === 'right'},
      ]"
    >
    </dx-input>
  </input-wrapper>
</template>

<script>
import ControlMixin from '../ControlMixin'
import InputWrapper from '../InputWrapper.vue'
import DxInput from 'devextreme-vue/number-box'

export default {
  mixins: [ControlMixin],
  components: {
    InputWrapper,
    DxInput
  },
  props: {
    allowNull: {
      type: Boolean,
      required: false,
      default: true
    },
    decimalDigits: {
      type: Number,
      required: false,
      default: 2
    },
    digits: {
      type: Number,
      required: false,
      default: 7
    },
    spinStep: {
      type: Number,
      required: false,
      default: 1
    },
    inputMode: {
      type: String,
      required: false,
      default: 'advanced'
    },
    max: {
      type: Number,
      required: false,
      default: function (props) {
        let value = ''
        value += '9'.repeat(props.digits)
        value += '.'
        value += '9'.repeat(props.decimalDigits)
        return Number(value)
      }
    },
    min: {
      type: Number,
      required: false,
      default: function (props) {
        let value = '-'
        value += '9'.repeat(props.digits)
        value += '.'
        value += '9'.repeat(props.decimalDigits)
        return Number(value)
      }
    },
    spinButtons: {
      type: Boolean,
      required: false,
      default: false
    },
    spinButtonsStep: {
      type: Number,
      required: false,
      default: 1
    },
    textAlign: {
      type: String,
      required: false,
      default: 'right'
    },
    value: {
      type: Number,
      required: false
    }
  },
  methods: {
    valueFormatter: function (value) {
      return Intl.NumberFormat('pl-PL', { maximumFractionDigits: this.decimalDigits, useGrouping: this.inputMode === 'advanced' }).format(value)
    }
  }
}
</script>

<style lang="scss">
</style>
