<template>
      <div class="screen">
        <div class="screen__content">
          <div class="logo-container">
          </div>
          <form class="login" @submit.prevent="registerForm" style="padding-top: 0px">
            <div class="login__field" style="padding-top:5px">
              <input type="text" class="login__input" v-bind:placeholder="'Email'" v-model="email">
              <div v-if="this.v$.email.$errors.length > 0 && this.email == ''"><span class="error_text">Podaj email</span></div>
            </div>
            <div class="login__field" style="padding-top:5px">
              <input type="text" class="login__input" v-bind:placeholder="'Login'" v-model="login">
              <div v-if="this.v$.login.$errors.length > 0 && this.login == ''"><span class="error_text">Podaj nazwę użytkownika</span></div>
            </div>
            <div class="login__field" style="padding-top:5px">
              <input type="password" class="login__input" v-bind:placeholder="'Hasło'" v-model="password">
              <div v-if="this.v$.password.$errors.length > 0 && this.password == ''"><span class="error_text">Podaj hasło</span></div>
            </div>
            <div class="login__field" style="padding-top:5px">
              <input type="text" class="login__input" v-bind:placeholder="'Powtórz hasło'" v-model="copyPassword">
              <div v-if="this.v$.copyPassword.$errors.length > 0 && this.copyPassword == ''"><span class="error_text">Powtórz hasło</span></div>
            </div>
            <div class="login__field" style="padding-top:5px">
              <input type="text" class="login__input" v-bind:placeholder="'Numer telefonu'" v-model="phoneNumber">
              <div v-if="this.v$.phoneNumber.$errors.length > 0 && this.phoneNumber == ''"><span class="error_text">Podaj number telefonu</span></div>
            </div>
            <button class="button login__submit" style="margin-top:0px">
              <span class="button__text">Zarejestruj się</span>
              <i class="button__icon fa fa-arrow-right"></i>
            </button>
              <div v-if="failed"><span class="error_text">Hasło musi mieć minimum 8 znaków w tym znak specjalny</span></div>
          </form>
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
import { mapState, mapActions } from 'vuex'

export default {
  data () {
    return {
      v$: useValidate(),
      email: '',
      login: '',
      password: '',
      copyPassword: '',
      phoneNumber: '',
      failed: false
    }
  },
  validations: {
    email: { required },
    login: { required },
    password: { required },
    copyPassword: { required },
    phoneNumber: { required }
  },
  computed: {
    ...mapState({ authenticated: (state) => state.auth.authenticated })
  },
  methods: {
    ...mapActions({ authenticate: 'auth/authenticate' }),
    async handleAuth () {
      await this.authenticate({
        EmailOrName: this.emailOrName,
        Password: this.password
      })
      if (this.authenticated) {
        this.$router.push('/administration')
      } else {
        this.showFailureMessage = true
      }
    },
    registerForm () {
      this.v$.$validate()
      if (!this.v$.$error) {
        this.axios.post('/identity/register', {
          Login: this.login,
          Email: this.email,
          Password: this.password,
          PasswordCopy: this.copyPassword,
          FirstName: 'Tsst',
          LastName: 'Test',
          PhoneNumber: this.phoneNumber,
          Language: 1,
          Profile: 2
        }).then(() => {
          this.$emit('eventname', true)
        }).catch(error => {
          this.failed = true
          console.log(error)
        })
      }
    }
  }
}
</script>
