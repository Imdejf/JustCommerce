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
      :dataSource="comboOptions"
      :searchMode="dropDownBoxConfig.optionsConfig.searchMode"
      v-model:text="searchText"
      :showSelectionControls="dropDownBoxConfig.showSelectionControls"
      :search-enabled="defaults.searchEnabled"
      :display-expr="defaults.displayExpression"
      :value-expr="defaults.valueExpression"
      :noDataText="'No data'"
      :showDropDownButton="defaults.showDropdown"
      :dropDownOptions="defaults.dropDownOptions"
      :buttons="dropDownBoxConfig.buttons"
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
import DropDownBoxMixin from './DropDownBoxMixin'

export default {
  mixins: [ControlMixin, DropDownBoxMixin],
  props: {},
  components: {
    TagBox,
    SelectBox,
    InputWrapper
  },
  computed: {
    comboOptions: function () {
      return this.dropDownBoxConfig.optionsConfig.options
    }
  }
}
</script>
