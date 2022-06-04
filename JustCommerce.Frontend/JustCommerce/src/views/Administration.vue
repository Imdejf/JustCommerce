<template>
    <div id="app" class="main" style="height: 100%">
      <div class="content-container flex">
        <div class="flex" style="margin-top: 0">
            <LeftMenu/>
        </div>
        <div class="content">
          <TopBar/>
        </div>
      </div>
    </div>
</template>

<script>
import LeftMenu from '@/components/Core/Menu/LeftMenu/LeftMenu.vue'
import TopBar from '@/components/Core/TopBar/TopBar.vue'

export default {
  components: {
    LeftMenu,
    TopBar
  }
}
</script>
