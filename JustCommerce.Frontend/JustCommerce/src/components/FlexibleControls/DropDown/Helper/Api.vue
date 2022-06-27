<template>
  <input-wrapper ref="wrapper" :config="wrapperConfig">
    <component
      ref="input"
      :is="dropDownBoxComponent"
      :value="config.value"
      @valueChanged="dropDownBoxValueChanged"
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
      :showSelectionControls="dropDownBoxConfig.showSelectionControls"
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

import ControlMixin from '../../ControlMixin'
import InputWrapper from '../../InputWrapper.vue'
import DropDownBoxMixin from '../DropDownBoxMixin'

export default {
  mixins: [ControlMixin, DropDownBoxMixin],
  data: function () {
    return {
      comboOptions: [],
      keyPressed: null
    }
  },
  components: {
    TagBox,
    SelectBox,
    InputWrapper
  },
  methods: {
    itemsUrl: function (searchQuery = '') {
      return this.dropDownBoxConfig.apiUrl + searchQuery
    },

    getInitialValues: async function () {
      if (!this.textToSync || !this.value) return
      if (this.dropDownBoxConfig.multiSelect) {
        await this.textToSync.forEach(async (item) => {
          if (this.comboOptions.some((x) => x.text === item)) return

          const url = this.itemsUrl(item)
          const { data } = await this.$axios.post(url, this.dropDownBoxConfig.formData)
          if (data) {
            this.comboOptions.push(...data)
          }
        })
      } else {
        if (this.comboOptions.some((x) => x.value === this.value)) return

        const url = this.itemsUrl(this.textToSync)
        const { data } = await this.$axios.post(url, this.dropDownBoxConfig.formData)
        if (data) {
          this.comboOptions.push(...data)
        }
      }
    }
  },
  mounted: async function () {
    alert()
    if ((this.value && !this.textToSync) || (!this.value && this.textToSync)) {
      throw new Error('dropDownBox in API mode needs both Value and Text specified!')
    }
    try {
      await this.getInitialOptions()
      await this.getInitialValues()
    } catch (e) {
      this.handleRetrievingDataError()
    }
    this.dropDownBoxValueChanged({ value: this.value })
    this.addWatchersOnFormDataUsedElements()
    this.$emit('initialized')
  }
}
</script>
