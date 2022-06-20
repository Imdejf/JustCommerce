import CustomStore from 'devextreme/data/custom_store'
import axios from 'axios'

export default (key, url) => {
  const store = new CustomStore({
    key: key,
    load: () => {
      return axios.get(url)
        .then(response => {
          return {
            data: response.data.Data,
            totalCount: response.data.Data.length
          }
        })
        .catch(error => {
          console.log(error)
          throw new Error('Failed to load grid data.')
        })
    }
  })
  return store
}
