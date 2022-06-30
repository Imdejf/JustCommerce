export default {
  props: {
    dropDownBoxConfig: {
      // obiekt z konfiguracją dropDownBox
      type: Object,
      required: true
    },
    value: {
      required: false,
      default: function (props) {
        return props.dropDownBoxConfig.multiSelect ? [] : ''
      }
    },
    textToSync: {
      required: false,
      default: function (props) {
        return props.dropDownBoxConfig.multiSelect ? [] : ''
      }
    }
  },
  computed: {
    inputInstance: function () {
      return this.$refs.input.instance
    },
    dropDownBoxComponent: function () {
      return this.dropDownBoxConfig.multiSelect ? 'TagBox' : 'SelectBox'
    },
    defaults: function () {
      return {
        searchEnabled: true,
        displayExpression: 'text',
        valueExpression: 'value',
        noDataText: 'dropDownBox.noData',
        showDropdown: true,
        dropDownOptions: {
          maxHeight: '200px'
        },
        multiline: false
      }
    },
    buttons: function () {
      if (!this.dropDownBoxConfig.showDataGridButton) return

      return [
        {
          options: {
            icon: 'fa fa-cog',
            stylingMode: 'text',
            hint: this.$t('dropDownBox.configure'),
            onClick: this.searchInDataGrid,
            elementAttr: {
              class: 'dropDownBox-configuration-button'
            }
          },
          name: 'Some button',
          location: 'before'
        },
        'dropDown'
      ]
    }
  },
  data: function () {
    return {
      searchText: null,
      internalText: null
    }
  },
  methods: {
    addWatchersOnFormDataUsedElements: function () {
      this.dropDownBoxConfig.formDataUsedElements.forEach(name => {
        this.$watch(`dropDownBoxConfig.formData.${name}`, this.getFreshOptionsFromApi)
      })
    },
    searchInDataGrid: function () {
      this.inputInstance.close()
      this.$nextTick(() => this.$emit('openDataGrid'))
    },
    updateText: function (newValue) {
      if (newValue === this.value) {
        // efekt uboczny zmiany wartości na stringi - wykonuje się update na tej samej wartości
        this.internalText = this.textToSync
        return
      }
      if (this.comboOptions.length === 0) return
      if (!newValue || newValue.length === 0) {
        this.internalText = newValue
        return
      }

      if (Array.isArray(newValue)) {
        this.internalText = [
          ...this.comboOptions.filter(e => newValue.some(x => x === e.value)).map(e => e.text)
        ]
      } else {
        const option = this.comboOptions.find(e => e.value === newValue)
        let value = null
        if (option) {
          value = option.text
        }

        this.internalText = value
      }
    },
    dropDownBoxValueChanged: function (event) {
      this.updateText(event.value)
      const emitValue = { value: event.value, text: this.internalText }
      this.$emit('valueUpdated', emitValue)
      if (this.dropDownBoxConfig.multiSelect) {
        this.inputInstance.field().value = ''
        const field = this.inputInstance.field()
        const event = new Event('input')

        field.dispatchEvent(event)
      }

      this.$nextTick(() => this.calculateErrors())
    },
    handleRetrievingDataError: function () {
      this.$utils.showErrorToast(this.$t('insertupdate.comboItemsError'))
    },

    getPreviouslySelectedValues: function (listToExclude) {
      if (this.dropDownBoxConfig.multiSelect) {
        const selectedValues = this.comboOptions.filter(e => this.value.some(x => x === e.value))
        return selectedValues
      }
      return [this.comboOptions.find(e => e.value === this.value)]
    },

    getOptions: async function (url) {
      const { data } = await this.axios.get(this.itemsUrl(url), this.dropDownBoxConfig.formData)
      // if (this.value) {
      //   const previouslySelected = this.getPreviouslySelectedValues(data)
      //   console.log('dwa')
      //   console.log(previouslySelected)

      //   const dataToPush = data.Data.filter(c => c.value !== previouslySelected[0].value)
      //   // const dataToPush = previouslySelected.filter(e =>
      //   //   data.every(dataElement =>
      //   //     dataElement.value !== e.value
      //   //   )
      //   // )
      //   data.Data.push(dataToPush)
      // }
      const dataOptions = []
      data.Data.map(function (value) {
        const dataObject = {
          value: value.FieldName,
          text: value.FieldName
        }
        dataOptions.push(dataObject)
        return value
      })
      this.comboOptions = dataOptions
    },

    addFirstCharacterToSearchBox: function () {
      if (!this.keyPressed) return
      if (this.keyPressed.length > 1) return

      this.inputInstance.field().value = this.keyPressed
      this.inputInstance.option('text', this.keyPressed)
      this.keyPressed = null
    },

    searchItems: async function (event) {
      let searchArgument = this.searchText
      if (!this.dropDownBoxConfig.multiSelect) {
        if (event.event) {
          // user wpisał coś w inputa
          this.dropDownBoxValueChanged({ value: null, text: null })
          this.$nextTick(() => this.addFirstCharacterToSearchBox())
        } else if (this.value) {
          searchArgument = ''
        }
      }
      try {
        await this.getOptions(searchArgument)
      } catch (e) {
        this.handleRetrievingDataError()
      }
    },
    getInitialOptions: async function () {
      const { data } = await this.axios.get(this.itemsUrl(), this.dropDownBoxConfig.formData)
      this.comboOptions = data
    },
    keyDown: function (event) {
      if (!this.value) return
      if (event.event.key === 'Backspace') {
        this.dropDownBoxValueChanged({ value: null, text: null })
        return
      }
      const key = event.event.key
      this.keyPressed = key
      if (!this.inputInstance.opened) {
        this.inputInstance.open()
      }
    },

    getFreshOptionsFromApi: async function () {
      await this.getInitialOptions()
      await this.getInitialValues()
    }
  }
}
