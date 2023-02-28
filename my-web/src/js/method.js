import axios from "axios";
/**
 * cách method
 * CreateBy: NMHUNG (26/12/2022)
 */
const methods = {
  /**
   * method get
   * CreateBy: NMHUNG (26/12/2022)
   */
  async get(api, query = "") {
    try {
      const response = await axios.get(`${api}${query}`);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },

  /**
   * method put
   * CreateBy: NMHUNG (26/12/2022)
   */
  async put(api, query = "", data) {
    const response = await axios.put(`${api}${query}`, data);
    return response.data;
  },

  /**
   * method post
   * CreateBy: NMHUNG (26/12/2022)
   */
  async post(api, data) {
    const response = await axios.post(`${api}`, data);
    return response.data;
  },

  /**
   * method delete
   * CreateBy: NMHUNG (26/12/2022)
   */
  async delete(api, query = "") {
    try {
      const response = await axios.delete(`${api}${query}`);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },
};

export default methods;
