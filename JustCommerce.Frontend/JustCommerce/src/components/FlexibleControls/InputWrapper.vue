<template>
  <div class="my-2 dx-input-wrapper">
    <div
      class="d-flex flex-column"
      :class="{ 'flex-row-reverse align-items-center justify-content-end': config.hideLabel }"
    >
      <div class="label-box ml-2 align-items-center">
        <span class="label" v-if="!config.hideLabel">{{ config.label }}</span>
        <div
          v-if="config.tooltip"
          :id="tooltipId"
          @mouseenter="tooltipVisible = true"
          @mouseleave="tooltipVisible = false"
          class="px-1 ml-1 mb-1"
        >
          <span class="d-inline-block">
            <i class="fas fa-circle"></i>
          </span>
          <dx-tooltip
            :visible="tooltipVisible"
            :target="'#' + tooltipId"
            :position="config.tooltipPlacement"
          >
            <template>
              <div v-html="config.tooltip"></div>
            </template>
          </dx-tooltip>
        </div>
      </div>
      <div
        :class="[
          { 'dx-input--error': config.errors.length && !config.hideLabel },
          { 'dx-input--value-required': isRequired === 'required' && !config.hideLabel },
          {
            'dx-input--value-required-conditionally':
              isRequired === 'conditionally' && !config.hideLabel
          }
        ]"
      >
        <slot></slot>
      </div>
    </div>
    <div v-if="currentError">
      <i class="far fa-exclamation-triangle error ml-1 mr-2"></i>
      <span class="error">{{ currentError }}</span>
    </div>
  </div>
</template>

<script>
import DxTooltip from 'devextreme-vue/tooltip'
export default {
  components: {
    DxTooltip
  },
  props: {
    config: {
      type: Object, // wrapperConfig z InputMixin
      required: true
    }
  },
  data: function () {
    return {
      tooltipVisible: false
    }
  },
  computed: {
    tooltipId: function () {
      return 'input-tooltip-' + this.$utils.generateId()
    },
    isRequired: function () {
      const validation = this.config.validation
      if (!(validation && validation.$params && validation.$params.required)) {
        return false
      }
      const validator = validation.$params.required
      if (validator.type === 'required') {
        return 'required'
      }
      if (validator.type === 'requiredIf') {
        return 'conditionally'
      }

      return false
    },
    currentError: function () {
      if (this.config.errors.length > 0) {
        return this.config.errors[0]
      } else {
        return null
      }
    }
  }
}
</script>
