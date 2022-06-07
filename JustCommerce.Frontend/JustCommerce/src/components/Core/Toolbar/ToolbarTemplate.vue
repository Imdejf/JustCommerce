<template>
  <div class="toolbar_menu_actions_item" style="height:100%; align-items:center;">
    <div class="toolbar-menu" v-for="(button, i) in buttons" :key="i">
      <BButton size="sm" variant="outline-success btn-circle btn-sm" @click="onClick(button)" v-b-tooltip.hover :title="button.text">
        <i :class="button.icon + ' ' + button.additionalIconClass"></i>
        <!-- <span>{{ $t(button.text) }}</span> -->
      </BButton>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    buttons: {
      type: Array,
      required: true,
      default: () => []
    }
  },
  methods: {
    onClick: async function (button) {
      button.onClick()
    }
  }
}
</script>
