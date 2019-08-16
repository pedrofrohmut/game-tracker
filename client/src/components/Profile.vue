<template>
  <div>Profile</div>
</template>

<script>
import axios from "axios"

export default {
  name: "Profile",
  data() {
    return {
      loading: false,
      error: null,
      profileData: null,
    }
  },
  beforeCreate() {
    document.body.className = "body-bg-no-image"
  },
  created() {
    this.loading = true
    const url = `http://localhost:5000/api/v1/apex/profiles/${this.$route.params.platform}/${this.$route.params.gamertag}`
    console.log("URL", url)
    axios
      .get(url)
      .then(response => {
        const respData = response.data.data
        console.log(respData)
        this.loading = false
      })
      .catch(err => {
        this.loading = false
        this.error = err.response.data.message
        console.log(this.error)
      })
  },
}
</script>

<style scoped></style>
