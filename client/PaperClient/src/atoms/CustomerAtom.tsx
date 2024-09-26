import {atom} from "jotai";
import {Customer} from "../Api.ts";

export const CustomersAtom = atom<Customer[]>([]);
export const SingleCustomerAtom = atom<Customer>({});