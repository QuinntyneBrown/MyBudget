/* tslint:disable */
import { CostCenterDto } from './cost-center-dto';
export interface CreateCostCenterResponse {
  costCenter?: CostCenterDto;
  validationErrors?: Array<string>;
}
