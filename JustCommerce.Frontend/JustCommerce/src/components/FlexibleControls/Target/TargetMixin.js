export default {
  props: {
    componentDataJson: {
      type: String,
      required: false
    }
  },
  computed: {
    wrapper: function () {
      return this.$refs.wrapper
    },
    dataObject: function () {
      if (this.componentDataJson) {
        return this.$utils.parseTargetParametersJson(this.componentDataJson)
      } else {
        return {}
      }
    },
    targetContext: function () {
      return {
        contextRefNum: this.dataObject.id,
        targetRefNum: this.dataObject.uid,
        self: this,
        forWrapper: {
          windowMode: this.dataObject.windowMode,
          windowSize: this.dataObject.modalSize
        }
      }
    },
    methods: {
      showLoader: function () {},
      hideLoader: function () {
        this.wrapper.toggleLoader(false)
      },
      showErrorToast: function (text) {
        this.$utils.showErrorToast(text, 3000)
      },
      showSuccessToast: function (text) {
        this.$utils.showInfoToast(text, 3000)
      },
      navigate: function (target, parameters, title) {
        this.$mainEventBus.$emit('navigate', null, null, null, title, target, parameters)
      },
      close: function () {
        if (this.targetContext.forWrapper.windowMode.includes('modal')) {
          this.$mainEventBus.$emit('executeModal', {
            target: null,
            targetRefno: null,
            targetParam: null
          })
        } else {
          this.$mainEventBus.$emit('navigate', null, null, null, null, null, null)
        }
      }
    }
  }
}
