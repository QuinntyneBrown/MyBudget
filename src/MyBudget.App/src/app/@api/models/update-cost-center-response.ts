/* tslint:disable */
import { CostCenterDto } from './cost-center-dto';
export interface UpdateCostCenterResponse {
  costCenter?: CostCenterDto;
  validationErrors?: Array<string>;
}
