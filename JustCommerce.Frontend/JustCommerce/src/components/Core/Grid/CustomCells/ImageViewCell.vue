<template>
  <div>
    <span>
      <span><img :src="cellData.value"/></span>
    </span>
  </div>
</template>

<script>
import CustomCells from './CustomCells.js'

export default {
  mixins: [CustomCells]
}
</script>
