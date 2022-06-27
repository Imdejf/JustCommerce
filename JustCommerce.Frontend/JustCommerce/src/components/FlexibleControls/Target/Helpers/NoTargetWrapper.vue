<template>
  <div class="current-component flex flex-column">
    <slot name="header"></slot>
    <slot name="content"></slot>
    <slot name="footer"></slot>
  </div>
</template>

<script>
import WrapperMixin from './WrapperMixin.js'

export default {
  mixins: [WrapperMixin]
}
</script>
