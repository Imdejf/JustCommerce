<template>
<div class="login-container login-body">
  <i class="fab fa-vuejs"></i>
  <div v-if="login">
    <LoginBox @eventname="updateparent"/>
  </div>
  <div v-else>
    <RegisterBox @eventname="updateparent"></RegisterBox>
  </div>
</div>
</template>
<script>
import LoginBox from '@/components/Core/Login/LoginBox.vue'
import RegisterBox from '@/components/Core/Login/Register.vue'
export default {
  components: {
    LoginBox,
    RegisterBox
  },
  data () {
    return {
      login: true
    }
  },
  methods: {
    updateparent (value) {
      this.login = value
    }
  },
  mounted () {
    this.$i18n.locale = localStorage.getItem('language')
  }
}
</script>
