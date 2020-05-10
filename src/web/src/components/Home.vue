<template>
  <div class="home">    
    <lotteryList :items=lotteryCollection />
  </div>  
</template>

<script>
import Repository from "../repositories/repositoryFactory";
const LotteryRepository = Repository.get("lotteries");

import lotteryList from "@/components/LotteryList";
export default {
  name: "Home",
  components: {
    lotteryList
  },
  data: function() {
    return {
      lotteryCollection: []
    }
  },
  methods: {
    getLotteries: async function() {
      const { data } = await LotteryRepository.get();
      return data;
    },
  },
  mounted: async function(){
    this.lotteryCollection = await this.getLotteries();
  }
};
</script>

<style>

</style>