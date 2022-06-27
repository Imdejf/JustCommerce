<template>
  <div class="position-relative d-flex flex-column flex-grow-1 u-min-height-0">
    <slot name="header"><!-- opcjonalne rozszerzenie headera modala, np. na grida --></slot>
    <div
      class="
        flex-grow-1
        d-flex
        flex-column
        rs-max-height-transition
        u-min-height-100px u-scrollbar-y
      "
      :class="{
        'u-max-height-100vh vh-100': this.targetConfig.fullHeight,
        'u-max-height-100vh': loaded && !this.targetConfig.fullHeight,
        'u-border-bottom-radius-normal': targetConfig.hideFooter
      }"
    >
      <tabs-management
        :tabs="targetConfig.tabs"
        :currentTabId="targetConfig.currentTabId"
        @tabChanged="tabChanged"
      ></tabs-management>
      <slot name="content" v-if="!targetConfig.useTabs"> </slot>
      <div v-for="tab in targetConfig.tabs" :key="tab.id" v-else v-show="isCurrentTab(tab)">
        <slot :name="tab.id"></slot>
      </div>
    </div>
    <div class="modal-footer" v-if="!targetConfig.hideFooter">
      <div class="button-area">
        <button class="btn btn-light" @click="$emit('close')">{{ $t("general.close") }}</button>
        <slot name="footer"> </slot>
      </div>
    </div>
  </div>
</template>

<script>
import WrapperMixin from './WrapperMixin.js'
import TabsManagement from './TabsManagement.vue'

export default {
  components: {
    TabsManagement
  },
  props: {
    fullHeight: {
      type: Boolean,
      required: false,
      default: false
    }
  },
  mixins: [WrapperMixin],
  data: function () {
    return {
      loaded: false
    }
  },
  computed: {
    customClass: function () {
      const classes = []
      if (this.targetConfig.fullHeight) {
        classes.push('u-height-1000')
      }
      return classes.join(' ')
    }
  },
  mounted: function () {
    this.targetContext.self.$parent.$emit(
      'setModalClass',
      this.targetContext.forWrapper.windowSize
    )
    this.targetContext.self.$parent.$emit('setTitle', this.targetConfig.title)
    this.targetContext.self.$parent.$emit('setIcon', this.targetConfig.icon)
  }
}
</script>
