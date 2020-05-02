<template>
  <div class="home">    
    <lotteryList :items=lotteryCollection />
  </div>  
</template>

<script>
import lotteryList from "@/components/lotteryList";
import axios from 'axios';
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
  mounted: function(){
    let self = this;
    axios
      .get('https://localhost:5001/lottery')
      .then(function (response) {
        console.log(response);
        self.lotteryCollection = response.data;
      })
      .catch(function (error) {
        console.log(error);
      });
  }
};
</script>

<style>
.app {  
}
</style>