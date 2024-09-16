/// <reference types="node" />

import axios from "axios";
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
    customerTypeDescription: customer.customerTypeDescription,
    customerStatusDescription: customer.customerStatusDescription,
  }));
}
