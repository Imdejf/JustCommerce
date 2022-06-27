<template>
    <div></div>
</template>

<script>
export default {
  props: {
    method: { type: Function }
  },
  mounted () {
    // Use the parent function directly here
    this.method()
  }
}
</script>
