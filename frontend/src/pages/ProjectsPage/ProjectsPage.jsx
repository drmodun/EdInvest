import { useEffect, useState } from "react";
import classes from "./index.module.css";

import { getItems } from "../../axios/ItemCalls/ItemsApiCalls";
import { getCategories } from "../../axios/CategoryCalls/CategoryApiCalls";
import { getSubcategories } from "../../axios/CategoryCalls/SubcategoryApiCalls";
import { getCourses } from "../../axios/ItemCalls/CourseApiCalls";
import { getApplications } from "../../axios/ItemCalls/ApplicationApiCalls";
import { getOnlineCourses } from "../../axios/ItemCalls/OnlineCourseApiCalls";
import { getEvents } from "../../axios/ItemCalls/EventApiCalls";
import SearchIcon from "../../assets/icons/search.svg";
import FilterIcon from "../../assets/icons/filter.svg";

import Card from "../../components/Card";
import Dropdown from "../../components/Dropdown";

const typeDictionary = {
  0: "Course",
  1: "Application",
  3: "Online Course",
  4: "Event",
};
const types = [
  { id: 0, name: "Course" },
  { id: 1, name: "Application" },
  { id: 3, name: "Online Course" },
  { id: 4, name: "Event" },
];
const ProjectsPage = () => {
  const [inputIsFocused, setInputIsFocused] = useState(false);
  const [inputValue, setInputValue] = useState("");
  const [categories, setCategories] = useState([]);
  const [subcategories, setSubcategories] = useState([]);
  const [selectedType, setType] = useState(null);
  const [categoryId, setCategoryId] = useState(null);
  const [subcategoryId, setSubcategoryId] = useState(null);
  const [sortCriteria, setSortCriteria] = useState("");
  const [topItems, setTopItems] = useState([]);
  const handleInputFocus = () => {
    if (inputIsFocused) {
      setInputIsFocused(false);
    } else {
      setInputIsFocused(true);
    }
  };

  const sortItems = {
    "A - Z": () => {
      const copiedItems = [...items];
      copiedItems.sort((a, b) => a.name.localeCompare(b.name));
      setItems(copiedItems);
    },
    "Z - A": () => {
      const copiedItems = [...items];
      copiedItems.sort((a, b) => b.name.localeCompare(a.name));
      setItems(copiedItems);
    },
    "Most Funded": () => {
      const copiedItems = [...items];
      copiedItems.sort((a, b) => b.currentAmount - a.currentAmount);
      setItems(copiedItems);
    },
    "Least Funded": () => {
      const copiedItems = [...items];
      copiedItems.sort((a, b) => a.currentAmount - b.currentAmount);
      setItems(copiedItems);
    },
    "Most Recent": () => {
      const copiedItems = [...items];
      copiedItems.sort((a, b) => new Date(b.updatedAt) - new Date(a.updatedAt));
      setItems(copiedItems);
    },
    //if cards add more propeeerties, add more sorting options
  };
  const sortingOptions = Object.keys(sortItems);
  const handleCriteriaSelect = (e) => {
    const value = e.target.innerHTML;
    setSortCriteria(value);
    sortItems[value]();
  };

  const [items, setItems] = useState([]);
  const fetchItems = async () => {
    const params = {
      Name: null,
      CategoryId: categoryId ? categoryId : null,
      SubcategoryId: subcategoryId ? subcategoryId : null,
    };
    try {
      let response = [];
      switch (selectedType) {
        case 0:
          response = await getCourses(params);
          setItems(response.courses);
          break;
        case 1:
          response = await getApplications(params);
          setItems(response.applications);
          break;
        case 3:
          response = await getOnlineCourses(params);
          setItems(response.onlineCourses);
          break;
        case 4:
          response = await getEvents(params);
          setItems(response.events);
          break;
        default:
          response = await getItems(params);
          setItems(response.items);
          if (topItems.length === 0)
            setTopItems(
              JSON.parse(
                JSON.stringify(
                  response.items
                    .sort((a, b) => b.currentAmount - a.currentAmount)
                    .slice(0, 3)
                )
              )
            );
          break;
      }
      console.log(response);
    } catch (err) {
      console.log(err);
    }
  };

  const handleCategoryChange = (value) => {
    setCategoryId(value);
    setSubcategoryId(null);
  };

  const fetchCategoriesAndSubcategories = async () => {
    const fetchCategories = await getCategories();
    const fetchSubcategories = await getSubcategories();
    setCategories(fetchCategories.categories);
    setSubcategories(fetchSubcategories.subcategories);
    console.log(fetchCategories);
    console.log(fetchSubcategories);
  };

  useEffect(() => {
    fetchItems();
    fetchCategoriesAndSubcategories();
    console.log(items, topItems);
  }, []);

  return (
    <>
      {/* SEARCH SECTION */}
      <section className={classes.sectionSearch}>
        <h1 className={classes.sectionSearchTitle}>Find your project</h1>
        <div className={classes.sectionSearchQuery}>
          <img src={SearchIcon} alt="search" />
          <input
            onChange={(e) => setInputValue(e.target.value)}
            type="text"
            placeholder="Search for a project, organisation or something else"
          />
        </div>
      </section>

      {/* EXAMPLES SECTION */}
      <section className={classes.sectionExamples}>
        <div className="layoutSpacing">
          <h2 className={classes.sectionExamplesTitle}>Take a look</h2>
          <div className={classes.sectionExamplesCards}>
            {topItems.map((item, i) => {
              return (
                <Card
                  key={i}
                  name={item.name}
                  type={typeDictionary[item.type]}
                  isVerified={true}
                  description={item.description}
                  raised={item.currentAmount ? item.currentAmount : "0"}
                  id={item.id}
                />
              );
            })}
          </div>
        </div>
      </section>

      {/* EXPLORE ALL SECTION */}
      <section className={classes.sectionExplore}>
        <div className={classes.sectionExploreFilters}>
          <div className="layoutSpacing">
            <span className={classes.FilterTitle}>Choose type:</span>
          </div>
          <div className="layoutSpacing">
            <div className={classes.sectionExplorerCategories}>
              <button
                className={
                  selectedType === null
                    ? classes.selected
                    : classes.sectionExploreFiltersButton
                }
                onClick={() => setType(null)}
              >
                All
              </button>
              {types.map((type) => {
                return (
                  <button
                    key={type.id}
                    className={
                      type.id === selectedType
                        ? classes.selected
                        : classes.sectionExploreFiltersButton
                    }
                    onClick={() => setType(type.id)}
                  >
                    {type.name}
                  </button>
                );
              })}
            </div>
          </div>
          <div className="layoutSpacing">
            <span className={classes.FilterTitle}>Choose category:</span>
          </div>
          <div className="layoutSpacing">
            <div className={classes.sectionExplorerCategories}>
              <button
                className={
                  categoryId === null
                    ? classes.selected
                    : classes.sectionExploreFiltersButton
                }
                onClick={() => setCategoryId(null)}
              >
                All
              </button>
              {categories.map((category) => {
                return (
                  <button
                    key={category.id}
                    className={
                      categoryId === category.id
                        ? classes.selected
                        : classes.sectionExploreFiltersButton
                    }
                    onClick={() => handleCategoryChange(category.id)}
                  >
                    {category.name}
                  </button>
                );
              })}
            </div>
            <button
              className={classes.sectionExploreFilter}
              onClick={fetchItems}
            >
              Filter
              <img src={FilterIcon} alt="Filter" />
            </button>
          </div>
          <div className="layoutSpacing">
            <span className={classes.FilterTitle}>Choose subcategory:</span>
          </div>
          <div className="layoutSpacing">
            <div className={classes.sectionExplorerCategories}>
              <button
                className={
                  subcategoryId === null
                    ? classes.selected
                    : classes.sectionExploreFiltersButton
                }
                onClick={() => setSubcategoryId(null)}
              >
                All
              </button>
              {categoryId && (
                <>
                  {subcategories
                    .filter(
                      (subcategory) => subcategory.categoryId === categoryId
                    )
                    .map((subcategory) => {
                      return (
                        <button
                          key={subcategory.id}
                          className={
                            subcategoryId === subcategory.id
                              ? classes.selected
                              : classes.sectionExploreFiltersButton
                          }
                          onClick={() => setSubcategoryId(subcategory.id)}
                        >
                          {subcategory.name}
                        </button>
                      );
                    })}
                </>
              )}
            </div>
          </div>
        </div>
        <div className={classes.sectionExploreSort}>
          <div className="layoutSpacing">
            <h3 className={classes.sectionExploreTitle}>
              Explore all
              <span>
                {
                  items.filter((item) => {
                    return item.name
                      .toLowerCase()
                      .includes(inputValue.toLowerCase());
                  }).length
                }{" "}
                projects
              </span>
            </h3>
            <Dropdown
              name="Sort by"
              value={sortCriteria}
              options={sortingOptions}
              isOpened={inputIsFocused}
              focusEffect={handleInputFocus}
              selectEffect={handleCriteriaSelect}
            />
          </div>
        </div>

        <div className={classes.sectionExploreCards}>
          <div className="layoutSpacing">
            {items
              .filter((item) => {
                return item.name
                  .toLowerCase()
                  .includes(inputValue.toLowerCase());
              })
              .map((item, i) => {
                return (
                  <Card
                    key={i}
                    name={item.name}
                    type={typeDictionary[item.type]}
                    isVerified={true}
                    description={item.description}
                    raised={item.currentAmount ? item.currentAmount : "0"}
                    id={item.id}
                  />
                );
              })}
          </div>
        </div>
      </section>
    </>
  );
};

export default ProjectsPage;
