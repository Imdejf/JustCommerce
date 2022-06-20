<template>
  <ControlWrapper ref="wrapper" :config="wrapperConfig">
    <dx-input
      ref="input"
      :value="config.value != null ? config.value.toString() : config.value"
      @valueChanged="onValueChanged"
      @input="onInput"
      :width="config.width"
      :height="config.height"
      :placeholder="config.placeHolder"
      :readOnly="config.readOnly"
      :maxLength="config.maxLength"
      :inputAttr="inputAttr"
      :onEnterKey="enterPressed"
      :showClearButton="clearButton"
    >
      <dx-text-box-button
        v-if="password"
        :options="passwordButton"
        name="password"
        location="after"
        class="dx-input-button"
      />
    </dx-input>
  </ControlWrapper>
</template>
<script>
import ControlMixin from '../ControlMixin'
import ControlWrapper from '../ControlWrapper.vue'
import DxInput, { DxButton as DxTextBoxButton } from 'devextreme-vue/text-box'

export default {
  mixins: [ControlMixin],
  components: {
    ControlWrapper,
    DxInput,
    DxTextBoxButton
  },
  props: {
    value: {
      required: false
    },
    maxLength: {
      type: Number,
      required: false,
      default: null
    },
    password: {
      type: Boolean,
      default: false
    },
    clearButton: {
      type: Boolean,
      required: false,
      default: false
    },
    disableButton: {
      type: Boolean,
      required: false,
      default: false
    }
  },
  computed: {
    inputAttr: function () {
      return {
        class: this.mode === 'password' ? 'text-as-disc' : '',
        autocomplete: 'new'
      }
    },
    passwordButton: function () {
      return {
        icon: this.buttonIcon,
        type: 'default',
        visible: true,
        disabled: this.disableButton,
        onClick: () => {
          this.mode = this.mode === 'text' ? 'password' : 'text'
        }
      }
    },
    buttonIcon: function () {
      return this.mode === 'text' ? 'far fa-eye-slash' : 'far fa-eye'
    }
  },
  methods: {
    enterPressed: function (event) {
      this.$emit('enterPressed')
    }
  },
  mounted: function () {
    this.mode = this.password ? 'password' : 'text'
  }
}
</script>
