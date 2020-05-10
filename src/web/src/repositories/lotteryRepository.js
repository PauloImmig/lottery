import Client from './clients/axiosClient';
const resource = '/lottery';

export default {
  get() {
    return Client.get(`${resource}`);
  },
  getPost(id) {
    return Client.get(`${resource}/${id}`);
  },
  getParticipants(id) {
    return Client.get(`${resource}/${id}/participants`);
  },
  create(payload) {
    return Client.post(`${resource}`, payload);
  },
  update(payload, id) {
    return Client.put(`${resource}/${id}`, payload);
  },
  delete(id) {
    return Client.delete(`${resource}/${id}`);
  },
};