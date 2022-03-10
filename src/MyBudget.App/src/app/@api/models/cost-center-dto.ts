/* tslint:disable */
import { CostCenterCategory } from './cost-center-category';
export interface CostCenterDto {
  category?: CostCenterCategory;
  costCenterId?: string;
  isEssential?: boolean;
  name?: string;
}
