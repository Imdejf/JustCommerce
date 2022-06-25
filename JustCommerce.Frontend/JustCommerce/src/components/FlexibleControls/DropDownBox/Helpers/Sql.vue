<template>
  <input-wrapper ref="wrapper" :config="wrapperConfig">
    <component
      ref="input"
      :is="comboflyComponent"
      :value="config.value"
      @valueChanged="comboflyValueChanged"
      :width="config.width"
      :height="config.height"
      :readOnly="config.readOnly"
      :placeholder="config.placeHolder"
      :onInput="searchItems"
      :onOpened="searchItems"
      :onKeyDown="keyDown"
      :dataSource="comboOptions"
      v-model:text="searchText"
      :buttons="buttons"
      :showSelectionControls="comboflyConfig.showSelectionControls"
      :search-enabled="defaults.searchEnabled"
      :display-expr="defaults.displayExpression"
      :value-expr="defaults.valueExpression"
      :noDataText="$t(defaults.noDataText)"
      :showDropDownButton="defaults.showDropdown"
      :dropDownOptions="defaults.dropDownOptions"
      :multiline="defaults.multiline"
    >
    </component>
  </input-wrapper>
</template>

<script>
import TagBox from 'devextreme-vue/tag-box'
import SelectBox from 'devextreme-vue/select-box'

import ControlMixin from '../../ControlMixin.js'
import InputWrapper from '../../InputWrapper.vue'
import DropDownBoxMixin from './DropDownBoxMixin.js'

export default {
  mixins: [ControlMixin, DropDownBoxMixin],
  data: function () {
    return {
      comboOptions: []
    }
  },
  components: {
    TagBox,
    SelectBox,
    InputWrapper
  },
  methods: {
    valuesUrl: function (value) {
      return (
        `sql/${this.comboflyConfig.sqlConfig.uid}/combofly-text?` +
        `value=${value}` +
        `&selectValueColumn=${this.comboflyConfig.sqlConfig.valueColumn}` +
        `&selectTextColumn=${this.comboflyConfig.sqlConfig.textColumn}` +
        `&selectHtmlColumn=${this.comboflyConfig.sqlConfig.htmlColumn}` +
        `&selectSearchColumn=${this.comboflyConfig.sqlConfig.searchColumn}` +
        `&searchType=${this.comboflyConfig.sqlConfig.searchType}` +
        '&query='
      )
    },
    itemsUrl: function (searchQuery = '') {
      return (
        `sql/${this.comboflyConfig.sqlConfig.uid}/items?` +
        `selectValueColumn=${this.comboflyConfig.sqlConfig.valueColumn}` +
        `&selectTextColumn=${this.comboflyConfig.sqlConfig.textColumn}` +
        `&selectHtmlColumn=${this.comboflyConfig.sqlConfig.htmlColumn}` +
        `&selectSearchColumn=${this.comboflyConfig.sqlConfig.searchColumn}` +
        `&searchType=${this.comboflyConfig.sqlConfig.searchType}` +
        `&query=${searchQuery}`
      )
    },

    getInitialValues: async function () {
      if (!this.value) return

      if (this.comboflyConfig.multiSelect) {
        await this.value.forEach(async item => {
          if (this.comboOptions.some(x => x.value === item)) return

          const url = this.valuesUrl(item)
          const { data } = await this.$axios.post(url, this.comboflyConfig.formData)
          if (data) {
            this.comboOptions.push({ value: item, text: data })
          }
        })
      } else {
        if (this.comboOptions.some(x => x.value === this.value)) return

        const url = this.valuesUrl(this.value)
        const { data } = await this.$axios.post(url, this.comboflyConfig.formData)
        if (data) {
          this.comboOptions.push({ value: this.value, text: data })
        }
      }
    }
  },
  mounted: async function () {
    try {
      await this.getInitialOptions()
      await this.getInitialValues()
    } catch (e) {
      this.handleRetrievingDataError()
    }
    this.comboflyValueChanged({ value: this.value })
    this.addWatchersOnFormDataUsedElements()
    this.$emit('initialized')
  }
}
</script>
