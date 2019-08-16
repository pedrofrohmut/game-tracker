import Vue from "vue"
import Router from "vue-router"
import Search from "./components/Search"
import Profile from "./components/Profile"

Vue.use(Router)

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "search",
      component: Search,
    },
    {
      path: "/profile/:platform/:gamertag",
      name: "profile",
      component: Profile,
    },
  ],
})
