<template>
  <component
    ref="wrapper"
    v-if="$wrapperComponent"
    :is="$wrapperComponent"
    :targetContext="targetContext"
    :targetConfig="$targetConfig"
    @close="close"
    @tabChanged="tabChanged"
  >
    <template #header>
      <slot name="header"> </slot>
    </template>
    <template #content>
      <slot name="content"> </slot>
    </template>
    <template v-slot:[tab.id] v-for="tab in tabs">
      <slot :name="tab.id"></slot>
    </template>
    <template #footer>
      <slot name="footer"> </slot>
    </template>
  </component>
</template>

<script>
import {
  ModalTargetWrapper,
  WithContainerTargetWrapper,
  WithoutContainerTargetWrapper,
  NoTargetWrapper
} from './Helpers'

export default {
  components: {
    ModalTargetWrapper,
    WithContainerTargetWrapper,
    WithoutContainerTargetWrapper,
    NoTargetWrapper
  },
  props: {
    targetContext: {
      type: Object,
      required: true
    },
    title: {
      type: String,
      required: false,
      default: ''
    },
    fullHeight: {
      type: Boolean,
      required: false,
      default: false
    },
    fullContainerWidth: {
      type: Boolean,
      required: false,
      default: false
    },
    hideFooter: {
      type: Boolean,
      required: false,
      default: false
    },
    tabs: {
      type: Array,
      required: false,
      default: null
    },
    currentTabId: {
      type: String,
      required: false,
      default: null
    },
    emitGlobalCloseEvent: {
      type: Boolean,
      required: false,
      default: true
    },
    icon: {
      type: String,
      required: false,
      default: ''
    }
  },
  computed: {
    $wrapperComponent: function () {
      switch (this.targetContext.forWrapper.windowMode) {
        case 'modal':
          return ModalTargetWrapper
        case 'nonModalWithContainer':
          return WithContainerTargetWrapper
        case 'nonModalWithoutContainer':
          return WithoutContainerTargetWrapper
        default:
          return NoTargetWrapper
      }
    },
    $targetConfig: function () {
      return {
        title: this.title,
        fullHeight: this.fullHeight,
        fullContainerWidth: this.fullContainerWidth,
        hideFooter: this.hideFooter,
        tabs: this.tabs,
        currentTabId: this.currentTabId,
        useTabs: this.useTabs,
        icon: this.icon
      }
    },
    useTabs: function () {
      return !!this.tabs
    }
  },
  methods: {
    toggleLoader: function (show) {
      if (!this.$refs.wrapper) {
        return
      }

      this.$refs.wrapper.toggleLoader(show)
    },
    close: function () {
      if (this.emitGlobalCloseEvent) {
        this.$mainEventBus.$emit('executeModal', {
          target: null,
          targetRefno: null,
          targetParam: null
        })
      } else {
        this.$emit('close')
      }
    },
    tabChanged: function (tabId) {
      this.$emit('update:currentTabId', tabId)
    }
  }
}
</script>
