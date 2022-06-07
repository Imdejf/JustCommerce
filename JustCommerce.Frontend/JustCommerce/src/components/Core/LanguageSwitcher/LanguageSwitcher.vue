<template>
    <ul>
        <li>
            <button @click.prevent="setLocale('en-EN')">En-en</button>
        </li>
        <li>
            <button @click.prevent="setLocale('pl-PL')">PL-pl</button>
        </li>    </ul>
</template>

<script>
export default {
  data: function () {
    return {
    }
  },
  methods: {
    setLocale (locale) {
      localStorage.setItem('language', locale)
      this.$i18n.locale = locale
      this.$router.push({
        params: { lang: locale }
      })
    }
  }
}
</script>
