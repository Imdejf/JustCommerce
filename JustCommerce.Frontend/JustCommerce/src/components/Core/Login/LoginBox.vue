<template>
      <div class="screen">
        <div class="screen__content">
          <div class="logo-container">
            <img alt="Vue logo" src="../../../assets/logo.png">
          </div>
          <form class="login" @submit.prevent="handleSubmit">
            <div class="login__field">
              <i class="login__icon fas fa-user"></i>
              <input type="text" class="login__input" placeholder="User name / Email" v-model="user.email">
              <div v-if="submitted && !$v.user.firstName.required" class="invalid-feedback">First Name is required</div>
            </div>
            <div class="login__field">
              <i class="login__icon fas fa-lock"></i>
              <input type="password" class="login__input" placeholder="Password">
            </div>
            <button class="button login__submit">
              <span class="button__text">Log In Now</span>
              <i class="button__icon fas fa-chevron-right"></i>
              <font-awesome-icon icon="arrow-right" />
            </button>
          </form>
          <div class="social-login">
            <h3>log in via</h3>
            <div class="social-icons">
              <a href="#" class="social-login__icon fab fa-instagram"><font-awesome-icon :icon="{ prefix: 'fab', iconName: 'google' }"/></a>
              <a href="#" class="social-login__icon fab fa-facebook"><font-awesome-icon :icon="{ prefix: 'fab', iconName: 'facebook' }"/></a>
              <a href="#" class="social-login__icon fab fa-twitter"><font-awesome-icon :icon="{ prefix: 'fab', iconName: 'twitter' }"/> </a>
            </div>
          </div>
        </div>
        <div class="screen__background">
          <span class="screen__background__shape screen__background__shape4"></span>
          <span class="screen__background__shape screen__background__shape3"></span>
          <span class="screen__background__shape screen__background__shape2"></span>
          <span class="screen__background__shape screen__background__shape1"></span>
        </div>
      </div>
</template>

<script>
import { required } from '@vuelidate/validators'

export default {
  data () {
    return {
      user: {
        email: '',
        password: ''
      },
      submitted: false
    }
  },
  validations: {
    user: {
      email: { required }
    }
  },
  methods: {
    handleSubmit (e) {
      this.submitted = true
      // stop here if form is invalid
      this.$v.$touch()
      if (this.$v.$invalid) {
        return
      }
      alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.user))
    }
  }
}
</script>
