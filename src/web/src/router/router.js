import Vue from 'vue';
import Router from 'vue-router';
import Home from '@/components/Home';
import About from '@/components/About';
import LotteryDetail from '@/components/LotteryDetail';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/Home',
      name: 'Home',
      component: Home
    },
    {
      path: '/lottery',
      name: 'NewLottery',
      component: LotteryDetail
    },
    {
      path: '/lottery/:id',
      name: 'LotteryDetail',
      component: LotteryDetail
    },
    {
      path: '/About',
      name: 'About',
      component: About
    }
  ]
});