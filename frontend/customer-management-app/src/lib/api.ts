/// <reference types="node" />

import axios from "axios";
import { CustomerStatus, CustomerType } from "../app/types";
import { Customer } from "../components/data-table/columns";

const apiUrl = process.env.NEXT_PUBLIC_API_URL;

export async function getCustomers(): Promise<Customer[]> {
  const response = await axios.get(`${apiUrl}/Customers`);
  const data = response.data;
  return data.items.map((customer: any) => ({
    id: customer.id,
    name: customer.name,
    cpf: customer.cpf,
    gender: customer.gender,
    customerTypeDescription: customer.customerType.description,
    customerStatusDescription: customer.customerStatus.description,
  }));
}

export async function getCustomerTypes(): Promise<CustomerType[]> {
  const response = await axios.get(`${apiUrl}/CustomerTypes`);
  return response.data;
}

export async function getCustomerStatuses(): Promise<CustomerStatus[]> {
  const response = await axios.get(`${apiUrl}/CustomerStatuses`);
  return response.data;
}

export async function createCustomer(customer: {
  name: string;
  cpf: string;
  gender: string;
  customerTypeId: number;
  customerStatusId: number;
}): Promise<void> {
  await axios.post(`${apiUrl}/Customers`, customer);
}

export async function deleteCustomer(id: number): Promise<void> {
  await axios.delete(`${apiUrl}/Customers/${id}`);
}

export async function getCustomerById(id: number): Promise<any> {
  const response = await axios.get(`${apiUrl}/Customers/${id}`);
  const customer = response.data;
  return {
    id: customer.id,
    name: customer.name,
    cpf: customer.cpf,
    gender: customer.gender,
    customerTypeId: customer.customerTypeId,
    customerStatusId: customer.customerStatusId,
  };
}

export async function updateCustomer(
  id: number,
  customer: {
    name: string;
    gender: string;
    customerTypeId: number;
    customerStatusId: number;
  }
): Promise<void> {
  await axios.put(`${apiUrl}/Customers/${id}`, customer);
}
