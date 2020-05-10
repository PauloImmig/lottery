import lotteryRepository from './lotteryRepository';

const repositories = {
  'lotteries': lotteryRepository
};
export default {
  get: name => repositories[name]
};