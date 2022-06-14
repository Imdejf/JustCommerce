<template>
  <div @mouseenter="tooltipVisible = true" @mouseleave="tooltipVisible = false">
    <i :class="iconClass" :id="'dx-icon-' + cellData.key"></i>
    <dx-tooltip
      v-if="tooltip"
      :visible="tooltipVisible"
      :target="'#dx-icon-' + cellData.key"
      :position="'top'"
    >
      <template>
        <div class="text-center">
          {{ tooltip }}
        </div>
      </template>
    </dx-tooltip>
  </div>
</template>

<script>
import CustomCells from './CustomCells.js'
import DxTooltip from 'devextreme-vue/tooltip'

export default {
  mixins: [CustomCells],
  components: {
    DxTooltip
  },
  data: function () {
    return {
      tooltipVisible: false
    }
  },
  computed: {
    iconClass: function () {
      return this.cellData.value
    },
    tooltip: function () {
      let tooltip
      if (this.cellData.tooltipColumn) {
        const tooltipColumn = Object.keys(this.cellData.rowData).find(
          key => key.toLowerCase() === this.cellData.tooltipColumn.toLowerCase()
        )
        tooltip = this.cellData.rowData[tooltipColumn]
      }
      if (!tooltip) {
        tooltip = this.cellData.tooltip
      }

      return tooltip
    }
  }
}
</script>
