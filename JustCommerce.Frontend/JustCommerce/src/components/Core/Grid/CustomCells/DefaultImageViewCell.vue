<template>
  <div>
    <span>
      <img :src="'data:image/png;base64,' + imageData" :alt="$t('dataGrid.noData')" />
    </span>
  </div>
</template>

<script>
import CustomCells from './CustomCells.js'

export default {
  mixins: [CustomCells],
  computed: {
    imageData: function () {
      const image = JSON.parse(this.cellData.value)

      return image.data
    }
  }
}
</script>
