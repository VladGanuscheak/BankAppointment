export interface Bank {
    bankId: number;
    bankName: string;
    url: string;
    branches: Branch[];
}

export interface Branch {
    branchId: number;
    phone: string;
    address: string;
    services: Service[];
}

export interface Service {
    serviceId: string;
    serviceName: string;
}