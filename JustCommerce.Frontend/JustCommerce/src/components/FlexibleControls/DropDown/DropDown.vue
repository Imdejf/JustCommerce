<template>
  <div>
    <component
      ref="input"
      :is="dropDownBoxComponent"
      :value="value"
      :textToSync="text"
      :width="width"
      :height="height"
      :validation="validation"
      :messages="messages"
      :disabled="disabled"
      :placeHolder="placeHolder"
      :tooltip="tooltip"
      :tooltipPlacement="tooltipPlacement"
      :dropDownBoxConfig="$config"
      @valueUpdated="dropDownBoxValueChanged"
      @initialized="$emit('initialized')"
      @openDataGrid="showDataGrid = true"
    >
    </component>
  </div>
</template>

<script>
import ControlMixin from '../ControlMixin.js'
import InputWrapper from '../InputWrapper.vue'
import { Api, Options } from './Helper'
import { TargetMixin, StandaloneModal } from '../Target'

export default {
  mixins: [ControlMixin, TargetMixin],
  components: {
    InputWrapper,
    Api,
    Options,
    StandaloneModal
  },
  data: function () {
    return {
      searchText: null,
      isReady: false,
      comboOptions: [],
      showDataGrid: false
    }
  },
  props: {
    value: {
      required: false
    },
    text: {
      required: false
    },
    options: {
      type: Array,
      required: false
    },
    multiSelect: {
      type: Boolean,
      required: false,
      default: false
    },
    sqlUid: {
      type: String,
      required: false
    },
    sqlValueColumn: {
      type: String,
      required: false,
      default: 'value'
    },
    sqlTextColumn: {
      type: String,
      required: false,
      default: 'text'
    },
    sqlHtmlColumn: {
      type: String,
      required: false,
      default: ''
    },
    sqlSearchColumn: {
      type: String,
      required: false,
      default: '___QUERY'
    },
    sqlSearchType: {
      type: String,
      required: false,
      default: 'Contains'
    },
    searchUrl: {
      type: String,
      default: null
    },
    formData: {
      type: Object,
      default: () => {
        return {}
      }
    },
    dataGridUid: {
      type: String,
      required: false,
      default: null
    },
    formDataUsedElements: {
      type: Array,
      required: false,
      default: () => []
    },
    optionsSearchType: {
      type: String,
      required: false,
      default: 'contains'
    },
    dictionaryMode: {
      type: Boolean,
      required: false,
      default: true
    },
    showButtons: {
      type: Boolean,
      required: false,
      default: true
    }
  },
  computed: {
    modalConfig: function () {
      return JSON.stringify([
        { id: 'fullHeight', value: 'true' },
        { id: 'windowMode', value: 'modal' },
        { id: 'title', value: 'modal' }
      ])
    },
    gridConigJson: function () {
      return JSON.stringify([
        { id: 'windowMode', value: 'modal' },
        { id: 'elementContextRequired', value: false },
        { id: 'allowManual', value: 'true' },
        { id: 'uid', value: this.dataGridUid },
        { id: 'listRefno', value: this.dataGridUid }
      ])
    },
    $config: function () {
      return {
        mode: this.dropDownBoxMode,

        apiUrl: this.searchUrl,
        showDataGridButton: !!this.dataGridUid,

        formData: this.formData,
        formDataUsedElements: this.formDataUsedElements,

        optionsConfig: {
          options: this.options,
          searchMode: this.optionsSearchType.toLowerCase()
        },
        multiSelect: this.multiSelect,

        showSelectionControls: this.showButtons && this.multiSelect
      }
    },
    dropDownBoxMode: function () {
      if (this.options && !this.searchUrl) {
        return 'options'
      } else if (this.searchUrl && !this.options) {
        return 'api'
      } else {
        throw new Error('Invalid combination of props, see comments in component file.')
      }
    },
    dropDownBoxComponent: function () {
      switch (this.dropDownBoxMode) {
        case 'options':
          return 'Options'
        case 'api':
          return 'Api'
        default:
          throw new Error('Error with dropDownBox initialization')
      }
    }
  },
  methods: {
    modalClosed: function () {
      if (this.dropDownBoxMode === 'options') {
        this.$emit('refreshData')
        this.showDataGrid = false
        return
      }
      this.$refs.input.getFreshOptionsFromApi()
      this.showDataGrid = false
    },
    dropDownBoxValueChanged: function (event) {
      this.$emit('update:value', event.value)
      this.$emit('update:text', event.text)
      this.$emit('changed')
    },
    calculateStringValue () {
      if (!this.value || this.dropDownBoxMode === 'options') return

      let internalValue
      if (this.multiSelect) {
        internalValue = this.value.map(e => e.toString())
      } else {
        internalValue = this.value.toString()
      }
      this.$emit('update:value', internalValue)
    }
  },
  mounted: function () {
  }
}
</script>
