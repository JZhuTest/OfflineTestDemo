import React, { useContext } from "react";
import { TopIngredient } from '../../types/TopIngredient';
import { TopIngredientContext } from '../../context';
import Select, { MultiValue, PropsValue } from 'react-select';

interface Props {
    selectedTops: TopIngredient[]
    handleTopSelectionChanged: (selectedTopItems: TopIngredient[]) => void;
  }

const TopMultiSelect:React.FC<Props> = ({
    selectedTops,
    handleTopSelectionChanged
}) => {
    const topIngredients: Array<TopIngredient> = useContext(TopIngredientContext);

    const handleSelectionChanged = (selectedOptions: MultiValue<TopIngredient>) => {
        handleTopSelectionChanged(selectedOptions.map(s => s));
    }
    return (
        <Select
              isMulti
              options={topIngredients}
              value={selectedTops}
              getOptionLabel={(option) => option.name}
              getOptionValue={(option) => option.id.toString()}
              onChange={ seletedItems => handleSelectionChanged(seletedItems)}
        />
    );
};

export default TopMultiSelect;