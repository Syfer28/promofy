import axios from "axios";
import Product from "../components/order-screen/Product";

const url = "192.168.1.18";

const apiClient = axios.create({
  baseURL: `http://${url}:5275/api/`,
});

export const getProduct = async () => {
  const response = await apiClient.get(
    "CombinedDataCompanyDistributorProductTables"
  );
  return response.data;
};

export const getCompany = async (id) => {
  const response = await apiClient.get(`Company/${id}`);
  return response.data;
};

export const getShop = async (id) => {
  const response = await apiClient.get(`Shop/${id}`);
  return response.data;
};

// export const getProductList = async () => {
//   const response = await apiClient.get(`ProductList`);
//   return response.data;
// };

// export const postProduct = async (product) => {
//   const response = await apiClient.post(`ProductList`, product);
//   return response.data;
// };
