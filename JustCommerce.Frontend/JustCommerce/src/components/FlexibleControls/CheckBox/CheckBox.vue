<template>
  <input-wrapper ref="wrapper" :config="wrapperConfig" :class="'rs-dx-input-wrapper--checkbox'">
    <dx-input
      :value="config.value"
      @valueChanged="onValueChanged"
      :width="config.width"
      :placeholder="config.placeHolder"
      :readOnly="config.readOnly"
      :text="config.text"
    >
    </dx-input>
  </input-wrapper>
</template>

<script>
import ControlMixin from '../ControlMixin'
import InputWrapper from '../InputWrapper.vue'
import DxInput from 'devextreme-vue/check-box'

export default {
  mixins: [ControlMixin],
  components: {
    InputWrapper,
    DxInput
  },
  props: {
    value: {
      type: Boolean,
      required: false
    },
    hasThreeStates: {
      type: Boolean,
      required: false,
      default: false
    }
  },
  data: function () {
    return {
      hideLabel: true
    }
  },
  mounted: function () {
    if (this.hasThreeStates && this.value === null) {
      this.onValueChanged({ value: undefined })
    }
    if (!this.hasThreeStates && (this.value === undefined || this.value === null)) {
      this.onValueChanged({ value: false })
    }
  }
}
</script>
