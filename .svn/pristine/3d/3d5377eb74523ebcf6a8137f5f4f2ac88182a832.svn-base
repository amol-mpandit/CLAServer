
const timeout = 60000

export const HTTP = {
  get (url, data) {
    return ajaxGet(url, data, 'GET')
  },

  post (url, data, contentType) {
    return ajaxPost(url, data, 'POST', contentType)
  }
}

let ajaxGet = (url, data, method) => {
  return new Promise((resolve, reject) => {
    this.$http.get({
      url: `${'http://AMOL-PC/CLAServer/'}${url}`,
      data: data,
      method: method,
      timeout: timeout
    })

    .done(result => {
      resolve(result)
    })

    .fail(error => {
      reject(error)
    })
  })
}
let ajaxPost = (url, data, method, contentType) => {
  return new Promise((resolve, reject) => {
    this.$http.post({
      url: `${'http://AMOL-PC/CLAServer/'}${url}`,
      data: data,
      method: method,
      timeout: timeout,
      contentType: contentType
    })

      .done(result => {
        resolve(result)
      })

      .fail(error => {
        reject(error)
      })
  })
}
