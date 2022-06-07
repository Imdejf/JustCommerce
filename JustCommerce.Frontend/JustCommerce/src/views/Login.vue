<template>
<div class="login-container login-body">
  <i class="fab fa-vuejs"></i>
  <LoginBox/>
</div>
</template>
<script>
import LoginBox from '@/components/Core/Login/LoginBox.vue'

export default {
  components: {
    LoginBox
  },
  mounted () {
    this.$i18n.locale = localStorage.getItem('language')
  }
}
</script>
