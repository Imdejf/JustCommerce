<template>
      <div class="screen">
        <div class="screen__content">
          <div class="logo-container">
            <img alt="Vue logo" src="../../../assets/logo.png">
          </div>
          <form class="login" @submit.prevent="submitForm">
            <div class="login__field">
              <i class="login__icon fas fa-user"></i>
              <input type="text" class="login__input" v-bind:placeholder="$t('login.userNameEmail')" v-model="emailOrName">
              <div v-if="this.v$.emailOrName.$errors.length > 0 && this.emailOrName == ''"><span class="error_text">Podaj nazwę użytkownika</span></div>
            </div>
            <div class="login__field">
              <i class="login__icon fas fa-lock"></i>
              <input type="password" class="login__input" v-bind:placeholder="$t('login.password')" v-model="password">
              <div v-if="this.v$.password.$errors.length > 0 && this.password == ''"><span class="error_text">Podaj hasło</span></div>
            </div>
            <button class="button login__submit">
              <span class="button__text">{{ $t("login.signIn") }}</span>
              <i class="button__icon fas fa-chevron-right"></i>
              <font-awesome-icon icon="arrow-right" />
            </button>
              <div v-if="failed"><span class="error_text">Niepoprawna nazwa użytkownika lub hasło</span></div>
          </form>
          <div class="social-login">
            <h3 style="font-size:larger">{{ $t("login.loginvia") }}</h3>
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
import useValidate from '@vuelidate/core'
import { required } from '@vuelidate/validators'

export default {
  data () {
    return {
      v$: useValidate(),
      emailOrName: '',
      password: '',
      failed: false
    }
  },
  validations: {
    emailOrName: { required },
    password: { required }
  },
  methods: {
    // submitForm () {
    //   this.v$.$validate()
    //   if (!this.v$.$error) {
    //     this.axios.defaults.baseURL = 'https://adminapi.justwin.pl/api/User'
    //     console.log(this.axios)
    //     this.axios.post('/login', {
    //       Email: this.emailOrName,
    //       Password: this.password
    //     }).then((response) => {
    //       console.log(response)
    //       this.$cookies.set('Authorization', response.data.Data.Jwt, '1d')
    //       this.$router.push('/')
    //     }).catch(error => {
    //       this.failed = true
    //       console.log(error)
    //     })
    //   }
    // }
    submitForm () {
      this.v$.$validate()
      const config = {
        headers: {
        }
      }
      const url = 'https://adminapi.justwin.pl/api/User/Login'

      const data = {
        Email: 'test@mymusic.pl',
        Password: 'Abc123!'
      }
      this.axios.post(url, config, data).then((response) => {
        console.log(response)
        this.$cookies.set('Authorization', response.data.Data.Jwt, '1d')
        this.$router.push('/')
      }).catch(error => {
        this.failed = true
        console.log(error)
      })
    }
  }
}
</script>
