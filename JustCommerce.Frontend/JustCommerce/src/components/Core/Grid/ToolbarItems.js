export default class ToolbarItems {
  constructor (vueContext, options) {
    if (!options) {
      options = {}
    }

    this.$vueContext = vueContext

    this.text = options.text
    this.icon = options.icon
    this.colorClass = options.colorClass
    this.contextRequired = options.contextRequired
    this.confirmationRequired = options.confirmationRequired
    this.confirmationText = options.confirmationText

    this.onClick = options.onClick

    this.lastToast = null
  }

  getText () {
    return this.text
  }

  getIcon () {
    return this.icon
  }

  getColorClass () {
    return this.colorClass
  }

  isContextRequired () {
    return this.contextRequired
  }

  isConfirmationRequired () {
    return this.confirmationRequired
  }

  getConfirmationText () {
    return this.confirmationText
  }

  invokeOnClick (context) {
    const invokeButton = () => {
      return new Promise((resolve, reject) => {
        try {
          resolve(this.onClick(context))
        } catch (error) {
          reject(error)
        }
      })
    }

    if (this.isConfirmationRequired()) {
      this.$vueContext.$toasted.error(this.getConfirmationText(), {
        theme: 'bubble',
        position: 'top-center',
        duration: null,
        action: [
          {
            text: 'yes',
            class: 'delete-action',
            onClick: (e, toast) => {
              toast.goAway(0)
              invokeButton()
            }
          },
          {
            text: 'no',
            class: 'delete-action',
            onClick: (e, toast) => {
              toast.goAway(0)
            }
          }
        ]
      })
    } else {
      invokeButton()
    }
  }

  static get handler () {
    return {
      add: (vueContext, onClickHandler) =>
        new ToolbarItems(vueContext, {
          text: 'Add',
          icon: 'fa fa-plus',
          colorClass: 'u-font-green',
          contextRequired: false,
          confirmationRequired: false,
          confirmationText: null,
          onClick: onClickHandler
        }),
      edit: (vueContext, onClickHandler) =>
        new ToolbarItems(vueContext, {
          text: 'Edit',
          icon: 'fa fa-edit',
          colorClass: 'u-font-orange',
          contextRequired: true,
          confirmationRequired: false,
          confirmationText: null,
          onClick: onClickHandler
        }),
      delete: (vueContext, onClickHandler) =>
        new ToolbarItems(vueContext, {
          text: 'Delete',
          icon: 'fa fa-trash',
          colorClass: 'text-danger',
          contextRequired: true,
          confirmationRequired: true,
          confirmationText: 'confirmQuestion',
          onClick: onClickHandler
        }),
      copy: (vueContext, onClickHandler) =>
        new ToolbarItems(vueContext, {
          text: 'Copy',
          icon: 'fa fa-copy',
          colorClass: 'u-font-green',
          contextRequired: true,
          confirmationRequired: false,
          confirmationText: null,
          onClick: onClickHandler
        })
    }
  }
}
