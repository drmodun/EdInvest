import { useState, useEffect } from "react";
import { getOrganisations } from "../../axios/UserCalls/OrganisationApiCalls";
import { getItems } from "../../axios/ItemCalls/ItemsApiCalls";

import HeaderBackground from "../../assets/header-background.png";
import ChevronRightBlack from "../../assets/chevron-right-black.svg";
import ChevronRightWhite from "../../assets/chevron-right-white.svg";
import ChevronRightBlue from "../../assets/chevron-right-blue.svg";
import SmilingGirlImg from "../../assets/smiling-girl-img.png";
import ArrowLeft from "../../assets/arrow-left.svg";
import classes from "./index.module.css";

import Card from "../../components/Card";
import { Link } from "react-router-dom";

const HomePage = () => {
  document
    .querySelector(":root")
    .style.setProperty("--header-background", "var(--color-blue)");
  document
    .querySelector(":root")
    .style.setProperty("--header-nav-color", "white");
  document
    .querySelector(":root")
    .style.setProperty("--header-button-bg-color", "white");
  document
    .querySelector(":root")
    .style.setProperty("--header-button-color", "#343434");

  const [items, setItems] = useState([]);
  const fetchItems = () => {
    getItems()
      .then((res) => res.items)
      .then((data) => setItems(data))
      .catch((err) => console.error(err));
  };

  useEffect(() => {
    fetchItems();
    const copiedItems = [...items];
    copiedItems.sort((a, b) => a.balance - b.balance);
    setItems(copiedItems.slice(0, 3));
  }, []);

  return (
    <div className="headerMargin">
      <div className={classes.HeaderHeroWrapper}>
        <img
          className={classes.HeaderHeroBackgroundImg}
          src={HeaderBackground}
          alt=""
        />
        <div className={classes.HeaderHeroTextWrapper}>
          <h1 className={classes.HeaderHeroTitle}>
            Invest in minds, supports with crypto
          </h1>
          <h3 className={classes.HeaderHeroSubtitle}>
            With blockchain technology, we transform project funding, esuring
            efficiency, trust, and accountability. Join us in reshaping
            education for a brighter future. Together, let's unlock the
            potential of education and make a lasting impact on learners
            worlwide.
          </h3>

          <div className={classes.HeaderHeroButtonsWrapper}>
            <Link to={"projects"}>
            <button className={classes.HeaderHeroWhiteButton}>
              <span className={classes.WhiteButtonText}>Explore projects</span>
              <img src={ChevronRightBlack} />
            </button>
            </Link>
            <button className={classes.TransparentButton}>
              <span className={classes.TransparentButtonText}>Our mission</span>
              <img src={ChevronRightWhite} />
            </button>
          </div>
        </div>
      </div>

      <div className={classes.TrustSection}>
        <h2 className={classes.TrustSectionTitle}>We have your back.</h2>
        <h4 className={classes.TrustSectionDescription}>
          Cryptocurrencies are built on blockchain technology, which provides a
          high level of security and transparency. Each transaction is securely
          recorded and verified on the blockchain, ensuring the integrity of the
          funding process.
        </h4>
        <button className={classes.TrustSectionButton}>
          <span className={classes.MarginRight17px}>Trust & Safety</span>
          <img src={ChevronRightBlue} alt="" />
        </button>
      </div>

      <div className={classes.PromoSectionWrapper}>
        <div className={classes.PromoSectionBackground}></div>
        <div className={classes.PromoSectionContent}>
          <div className={classes.PromoSectionLeft}>
            <h2 className={classes.PromoSectionLeftTitle}>Worth investing</h2>
            <h4 className={classes.PromoSectionLeftDescription}>
              There's a reason high net worth individuals tend to donate
              property instead of cash.
            </h4>
          </div>
          <div className={classes.PromoSectionRight}>
            <div className={classes.PromoSectionRightButtonsContainer}>
              <button className={classes.PromoSectionLeftButton}>
                <img src={ArrowLeft} alt="" />
              </button>
              <button className={classes.PromoSectionRightButton}>
                <img src={ArrowLeft} alt="" />
              </button>
            </div>
            <div className={classes.PromoSectionRightCardsContainer}>
              {/* <div className={classes.Card}></div>
              <div className={classes.Card}></div>
              <div className={classes.Card}></div> }
              <Card />
              <Card />
              <Card />
              */}
              {items.slice(0, 5).map((item, i) => {
                return (
                  <Card
                    key={i}
                    name={item.name}
                    type={item.type}
                    isVerified={false}
                    description={item.description}
                    raised={item.currentAmount}
                    id={item.id}
                  />
                );
              })}
            </div>
          </div>
        </div>
      </div>

      <div className={classes.AboutSectionWrapper}>
        <div className={classes.AboutSectionLeft}>
          <h2 className={classes.AboutSectionTitle}>What is EdInvest?</h2>
          <p className={classes.AboutSectionText}>
            EdInvest is an innovative platform that uses crypto funding to
            support education projects. Our platform allows individuals to
            contribute, invest, and donate to a wide range of education
            projects. By accepting cryptocurrencies, we make it easy for people
            around the world to get involved.
          </p>
          <button className={classes.TrustSectionButton}>
            <span className={classes.MarginRight17px}>MORE ABOUT US</span>
            <img src={ChevronRightBlue} alt="" />
          </button>
        </div>
        <div className={classes.AboutSectionRight}>
          <div className={classes.AboutSectionRightContainer}>
            <div className={classes.RightCircleBlue}></div>
            <div>
              <h4 className={classes.AboutSectionRightTitle}>
                Diverse educational projects
              </h4>
              <p className={classes.AboutSectionRightText}>
                Projects that empowering learners of all ages and backgrounds.
              </p>
            </div>
          </div>
          <div className={classes.AboutSectionRightContainer}>
            <div className={classes.RightCircleGreen}></div>
            <div>
              <h4 className={classes.AboutSectionRightTitle}>
                Fast and safe transactions
              </h4>
              <p className={classes.AboutSectionRightText}>
                Fast and secure transactions on our platform for all your
                contributions.
              </p>
            </div>
          </div>
          <div className={classes.AboutSectionRightContainer}>
            <div className={classes.RightCirclePurple}></div>
            <div>
              <h4 className={classes.AboutSectionRightTitle}>Zero fraud</h4>
              <p className={classes.AboutSectionRightText}>
                Secure environment where your contributions are protected
              </p>
            </div>
          </div>
        </div>
      </div>

      <div className={classes.StatsSection}>
        <div className={classes.StatsSectionContainer}>
          <p className={classes.StatsSectionSmallText}>Invested so far</p>
          <h1 className={classes.StatsSectionBigText}>2550€</h1>
        </div>
        <div className={classes.StatsSectionContainer}>
          <p className={classes.StatsSectionSmallText}>Projects on EdInvest</p>
          <h1 className={classes.StatsSectionBigText}>117</h1>
        </div>
        <div className={classes.StatsSectionContainer}>
          <p className={classes.StatsSectionSmallText}>Number of investitors</p>
          <h1 className={classes.StatsSectionBigText}>45</h1>
        </div>
      </div>

      <div className={classes.MoreInfoSection}>
        <div className={classes.MoreInfoWrapper}>
          <div className={classes.MoreInfoContainer}>
            <h2 className={classes.MoreInfoTitle}>
              Save on your taxes by investing with crypto
            </h2>
            <p className={classes.MoreInfoText}>
              There's a reason high net worth individuals tend to donate
              property instead of cash. Want to maximize your tax savings via
              charitable giving? This is how.
            </p>
            <button className={classes.TrustSectionButton}>
              <span className={classes.MarginRight17px}>FIND OUT MORE</span>
              <img src={ChevronRightBlue} alt="" />
            </button>
          </div>
          <div className={classes.SuccessCardWrapper}>
            <div className={classes.SuccessCardContainer}>
              <img src={SmilingGirlImg} alt="Smiling Girl Image" />
              <h3 className={classes.SuccessCardText}>
                See how Dump finally manifested his success story with help of
                EdInvest
              </h3>
            </div>
          </div>
        </div>
      </div>
      <div className={classes.UpToDateSection}>
        <h2 className={classes.UpToDateSectionTitle}>
          Want to stay up to date and receive more infromations?
        </h2>
        <p className={classes.UpToDateSectionText}>
          Be the first to receive exciting updates and inspiring success stories
        </p>
        <div className={classes.UpToDateSectionForm}>
          <input
            placeholder="Email"
            className={classes.UpToDateSectionInput}
          ></input>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
