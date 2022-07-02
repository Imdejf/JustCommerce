import axios from 'axios'
import jwtDecode from 'jwt-decode'
import cookies from 'vue-cookies'

export default {
  namespaced: true,
  state: {
    userInfo: {},
    activeLanguages: {}
  },
  mutations: {
    refreshData (state, payload) {
      state.activeLanguages = payload.activeLanguages
    },
    setUserInfo (state, payload) {
      state.userInfo = payload
    }
  },
  actions: {
    refreshData (context) {
      /*eslint-disable */
        return new Promise(async (resolve, reject) => {
          try {
            const data = {
              activeLanguages: []
            };

            const languageResponse = await axios.get("language");
            console.log(languageResponse)
            data.activeLanguages = languageResponse.langs.Data.map(lang => ({
              id: lang.id,
              value: lang.langIsoCode,
              text: lang.textOriginal
            }));
           // data.defaultLanguage = languageResponse.data.defaultLanguage;
            context.commit("refreshData", data);
            resolve();
          } catch (error) {
            reject(error);
          }
        });
        /* eslint-enable */
    },
    async setUserInfo (context) {
      const token = cookies.get('Authorization')
      const decoded = jwtDecode(token)
      await axios.get('Identity/' + decoded.Id).then(response => {
        context.commit('setUserInfo', response.data.Data)
      })
    }
  }
}
