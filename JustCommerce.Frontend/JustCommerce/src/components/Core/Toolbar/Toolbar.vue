<template>
  <div style="height:100%">
    <ToolbarTemplate :buttons="config.buttons"> </ToolbarTemplate>
  </div>
</template>
<script>
import ToolbarTemplate from './ToolbarTemplate.vue'
export default {
  components: {
    ToolbarTemplate
  },
  props: {
    config: {
      type: Object,
      required: true
    }
  }
}
</script>
