<template>
  <input-wrapper ref="wrapper" :config="wrapperConfig" :class="'rs-dx-input-wrapper--textarea'">
    <dx-input
      ref="input"
      :value="config.value"
      @valueChanged="onValueChanged"
      @input="onInput"
      :width="config.width"
      :height="config.height"
      :placeholder="config.placeHolder"
      :readOnly="config.readOnly"
      :maxLength="config.maxLength"
    >
    </dx-input>
  </input-wrapper>
</template>

<script>
import ControlMixin from '../ControlMixin.js'
import InputWrapper from '../InputWrapper.vue'
import DxInput from 'devextreme-vue/text-area'

export default {
  mixins: [ControlMixin],
  components: {
    InputWrapper,
    DxInput
  },
  props: {
    value: {
      type: String,
      required: false,
      default: ''
    },
    maxLength: {
      type: Number,
      required: false,
      default: null
    },
    height: {
      default: '100px'
    }
  }
}
</script>
<style lang="scss"></style>
