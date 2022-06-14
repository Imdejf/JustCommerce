<template>
  <div>
    <span>
      <a :href="link" target="_blank">{{ cellData.value }}</a>
    </span>
  </div>
</template>

<script>
import CustomCells from './CustomCells.js'

export default {
  mixins: [CustomCells],
  computed: {
    link: function () {
      const link = this.cellData.value
      if (!link) {
        return ''
      }

      if (link.startsWith('http')) {
        return link
      }

      return 'http://' + link
    }
  }
}
</script>
