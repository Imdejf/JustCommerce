<template>
  <div class="rs-dx-progressbar">
    <div
      :class="progressBarColorClass"
      :style="'width:' + cellData.value + '%'"
      class="rs-dx-progressbar__value"
    >
      <div class="rs-dx-progressbar__text">{{ cellData.value }}</div>
    </div>
  </div>
</template>

<script>
import CustomCells from './CustomCells.js'

export default {
  mixins: [CustomCells],
  computed: {
    progressBarColorClass: function () {
      const value = this.cellData.value
      if (value < 21) return 'bg-progress-xsmall'
      if (value < 41) return 'bg-progress-small'
      if (value < 61) return 'bg-progress-medium'
      if (value < 81) return 'bg-progress-large'

      return 'bg-progress-full'
    }
  }
}
</script>
