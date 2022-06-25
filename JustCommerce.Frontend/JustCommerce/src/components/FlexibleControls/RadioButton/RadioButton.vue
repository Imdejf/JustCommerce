<template>
  <input-wrapper ref="wrapper" :config="wrapperConfig" :class="'dx-input-wrapper--radio'">
    <dx-input
      :value="radioValue"
      @valueChanged="radioValueChanged"
      :width="config.width"
      :height="config.height"
      :readOnly="config.readOnly"
      :dataSource="config.options"
      :layout="config.layout"
      class="pl-2"
    >
    </dx-input>
  </input-wrapper>
</template>

<script>
import ControlMixin from '../ControlMixin'
import InputWrapper from '../InputWrapper.vue'
import DxInput from 'devextreme-vue/radio-group'

export default {
  mixins: [ControlMixin],
  components: {
    InputWrapper,
    DxInput
  },
  props: {
    value: {
      type: String,
      required: false
    },
    options: {
      type: Array,
      required: true
    },
    useHorizontalLayout: {
      type: Boolean,
      required: false,
      default: false
    }
  },
  computed: {
    radioValue: function () {
      return this.options.find((e) => e.value === this.value)
    }
  },
  methods: {
    radioValueChanged: function (event) {
      const value = event.value.value
      this.onValueChanged({ value: `${value}` })
    }
  }
}
</script>
