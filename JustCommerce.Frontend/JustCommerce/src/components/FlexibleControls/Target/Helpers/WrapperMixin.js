export default {
  props: {
    targetContext: {
      type: Object,
      required: true
    },
    targetConfig: {
      type: Object,
      required: true
    }
  },
  data: function () {
    return {
      contentLoaded: false
    }
  },
  computed: {
    hasFooter: function () {
      return !!this.$slots.footer
    }
  },
  methods: {
    toggleLoader: function (show) {
      if (show) {
        this.loaded = false
      } else {
        this.loaded = true
      }
    },
    isCurrentTab: function (tab) {
      return this.targetConfig.currentTabId === tab.id
    },
    tabChanged: function (tabId) {
      this.$emit('tabChanged', tabId)
    }
  }
}
