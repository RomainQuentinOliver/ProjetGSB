-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 07 jan. 2022 à 08:21
-- Version du serveur :  5.7.31
-- Version de PHP : 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gsb`
--

-- --------------------------------------------------------

--
-- Structure de la table `dosage`
--

DROP TABLE IF EXISTS `dosage`;
CREATE TABLE IF NOT EXISTS `dosage` (
  `DOS_CODE` int(11) NOT NULL,
  `DOS_QUANTITE` int(11) NOT NULL,
  `DOS_UNITE` char(10) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`DOS_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `dosage`
--

INSERT INTO `dosage` (`DOS_CODE`, `DOS_QUANTITE`, `DOS_UNITE`) VALUES
(1, 1000, 'mg'),
(2, 500, 'mg'),
(3, 300, 'mg'),
(5, 200, 'mg'),
(6, 100, 'mg');

-- --------------------------------------------------------

--
-- Structure de la table `famille`
--

DROP TABLE IF EXISTS `famille`;
CREATE TABLE IF NOT EXISTS `famille` (
  `FAM_CODE` int(11) NOT NULL AUTO_INCREMENT,
  `FAM_LIBELLE` char(80) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`FAM_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `famille`
--

INSERT INTO `famille` (`FAM_CODE`, `FAM_LIBELLE`) VALUES
(1, 'Antihistaminique'),
(2, 'Antidépresseur'),
(4, 'Antibiotique'),
(5, 'Anti-inflammatoires'),
(6, 'Antibactériens'),
(7, 'Antipyrétique'),
(8, 'Antilépreux'),
(9, 'Antimycosiques'),
(10, 'Antiviraux'),
(11, 'Cardiologie'),
(12, 'Dermatologie'),
(13, 'Antiacides');

-- --------------------------------------------------------

--
-- Structure de la table `interagir`
--

DROP TABLE IF EXISTS `interagir`;
CREATE TABLE IF NOT EXISTS `interagir` (
  `MED_PERTURBATEUR` int(11) NOT NULL,
  `MED_MED_PERTURBE` int(11) NOT NULL,
  PRIMARY KEY (`MED_PERTURBATEUR`,`MED_MED_PERTURBE`),
  KEY `MED_PERTURBATEUR` (`MED_PERTURBATEUR`,`MED_MED_PERTURBE`),
  KEY `MED_MED_PERTURBE` (`MED_MED_PERTURBE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `interagir`
--

INSERT INTO `interagir` (`MED_PERTURBATEUR`, `MED_MED_PERTURBE`) VALUES
(2, 1),
(3, 1),
(5, 1),
(3, 2),
(7, 2),
(17, 2),
(2, 3),
(9, 3),
(20, 3),
(8, 4),
(9, 4),
(10, 4),
(13, 4),
(16, 4),
(17, 4),
(7, 5),
(12, 5),
(1, 6),
(5, 6),
(1, 7),
(14, 7),
(4, 8),
(5, 8),
(2, 9),
(6, 9),
(13, 9),
(12, 10),
(5, 11),
(6, 11),
(15, 11),
(3, 12),
(7, 12),
(14, 13),
(4, 14),
(6, 14),
(7, 14),
(10, 14),
(4, 15),
(9, 15),
(4, 16),
(19, 16),
(5, 17),
(9, 17),
(18, 17),
(11, 18),
(10, 19),
(17, 19),
(7, 20),
(8, 20),
(16, 20),
(17, 20),
(18, 20);

-- --------------------------------------------------------

--
-- Structure de la table `medicament`
--

DROP TABLE IF EXISTS `medicament`;
CREATE TABLE IF NOT EXISTS `medicament` (
  `MED_DEPOTLEGAL` int(11) NOT NULL AUTO_INCREMENT,
  `MED_NOMCOMMERCIAL` char(25) COLLATE utf8_bin NOT NULL,
  `FAM_COD` int(11) NOT NULL,
  `MED_COMPOSITION` longtext COLLATE utf8_bin NOT NULL,
  `MED_EFFETS` longtext COLLATE utf8_bin NOT NULL,
  `MED_CONTREINDIC` longtext COLLATE utf8_bin NOT NULL,
  `MED_PRIXECHANTILLON` double NOT NULL,
  PRIMARY KEY (`MED_DEPOTLEGAL`),
  KEY `FAM_COD` (`FAM_COD`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `medicament`
--

INSERT INTO `medicament` (`MED_DEPOTLEGAL`, `MED_NOMCOMMERCIAL`, `FAM_COD`, `MED_COMPOSITION`, `MED_EFFETS`, `MED_CONTREINDIC`, `MED_PRIXECHANTILLON`) VALUES
(1, 'DOLIPRANE', 4, 'Citalopram	20 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Citalopram\r\nExcipients à effets notoires ? : Lactose\r\nAutres excipients: Amidon de maïs, Copovidone, Glycérine, Cellulose microcristalline, Croscarmellose sodique, Magnésium stéarate, Hypromellose, Macrogol 400, Titane dioxyde', 'Somnolence\r\nCéphalée\r\nAugmentation de l\'appétit\r\nInsomnie\r\nNervosité\r\nFatigue\r\nRéaction dhypersensibilitéCitalopram	20 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Citalopram\r\nExcipients à effets notoires ? : Lactose\r\nAutres excipients: Amidon de maïs, Copovidone, Glycérine, Cellulose microcristalline, Croscarmellose sodique, Magnésium stéarate, Hypromellose, Macrogol 400, Titane dioxyde', 'Insuffisance hépatocellulaire sévère\r\nEnfant avant 6 ans\r\nConsommation dalcool\r\n·         Hypersensibilité à la substance active ou à lun des excipients mentionnés à la rubrique Composition.\r\n·         Insuffisance hépatocellulaire sévère.\r\n·         Enfant de moins de 6 ans, en raison des risques de fausse route.', 2),
(2, 'EFFERALGAN', 7, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Sorbitol , Talc , Méthacrylate basique copolymère , Magnésium oxyde léger , Carmellose sodique , Sucralose , Magnésium stéarate , Hypromellose , Stéarique acide , Sodium laurylsulfate , Titane dioxyde , N,2,3-triméthyl-2-(propan-2-yl) butanamide , Siméticone , Arôme fraise : Maltodextrine , Gomme arabique , Substance aromatisante naturelle et , Substances aromatisantes identiques aux naturelles , Propylène glycol , Glycéryle triacétate , 3-hydroxy-2-méthyl-4H-pyran-4-one , Arôme vanille : Maltodextrine , Substance aromatisante naturelle , Substances aromatisantes identiques aux naturelles , Propylène glycol , Saccharose', 'Anémie\r\nAnémie non hémolytique\r\nDépression de la moelle osseuse\r\nThrombopénie\r\nLeucopénie\r\nNeutropénie\r\nOedème', 'Insuffisance hépatocellulaire sévère\r\nMaladie hépatique décompensée\r\nIntolérance au fructose\r\nMalabsorption du glucose-galactose\r\nHypersensibilité à la substance active ou à l\'un des excipients mentionnés à la rubrique Liste des excipients.\r\n\r\nInsuffisance hépatocellulaire sévère ou maladie hépatique active décompensée.', 2),
(3, 'LORATADINE', 10, 'Loratadine	10 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Loratadine\r\nExcipients à effets notoires ? : Noyau : Lactose monohydraté\r\nAutres excipients: Cellulose microcristalline, Amidon de maïs, Amidon prégélatinisé, Silice colloïdale hydratée, Magnésium stéarate, Pelliculage : Hypromellose, Macrogol 400 et 6000, Cire de carnauba, Talc', 'Somnolence\r\nCéphalée\r\nAugmentation de l\'appétit\r\nInsomnie\r\nNervosité\r\nFatigue\r\nRéaction d\'hypersensibilitéCitalopram	20 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Citalopram\r\nExcipients à effets notoires ? : Lactose\r\nAutres excipients: Amidon de maïs, Copovidone, Glycérine, Cellulose microcristalline, Croscarmellose sodique, Magnésium stéarate, Hypromellose, Macrogol 400, Titane dioxyde', 'Enfant de moins de 30 kg\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose\r\nSyndrome de malabsorption du glucose\r\nSyndrome de malabsorption du galactose\r\nDéficit en lactase\r\nGrossesse', 1),
(4, 'CITALOPRAM', 5, 'Citalopram	20 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Citalopram\r\nExcipients à effets notoires ? : Lactose\r\nAutres excipients: Amidon de maïs, Copovidone, Glycérine, Cellulose microcristalline, Croscarmellose sodique, Magnésium stéarate, Hypromellose, Macrogol 400, Titane dioxyde', 'Thrombocytopénie\r\nHypersensibilité\r\nRéaction anaphylactique\r\nSécrétion inappropriée d\'ADH\r\nDiminution de l\'appétit\r\nDiminution du poids\r\nAugmentation de l\"appétit', 'Insuffisance rénale sévère (Clcr < 20 ml/mn)\r\nEnfant de moins de 18 ans\r\nAllongement de l\'intervalle QT\r\nIntolérance au lactose\r\nConsommation d\'alcool\r\nEpilepsie non contrôlée\r\nGrossesse\r\nCe médicament NE DOIT JAMAIS être prescrit dans les cas suivants :\r\n\r\n·         hypersensibilité à la substance active ou à l\'un des excipients mentionnés à la rubrique Liste des excipients ;\r\n\r\n·         insuffisance rénale sévère avec clairance de la créatinine inférieure à 20 ml/min, en l\'absence de données ;\r\n\r\n·         association aux inhibiteurs de la monoamine oxydase (IMAO) irréversibles en raison du risque de syndrome sérotoninergique (voir rubrique Interactions avec d\'autres médicaments et autres formes d\'interactions) ;\r\n\r\n·         le citalopram ne doit pas être administré pendant 14 jours après l\'arrêt d\'un IMAO irréversible ou pendant le temps spécifié dans les mentions légales d\'un IMAO réversible après l\'arrêt de celui-ci ;\r\n\r\n·         les IMAO ne doivent pas être administrés pendant sept jours après l\'arrêt du citalopram ;\r\n\r\n·         association avec le pimozide (voir rubrique Interactions avec d\'autres médicaments et autres formes d\'interactions) ;\r\n\r\n·         chez les patients présentant un allongement acquis ou congénital de l\'intervalle QT ;\r\n\r\n·         association avec un autre médicament qui pourrait  entraîner un allongement du QT (voir rubrique Interactions avec d\'autres médicaments et autres formes d\'interactions).', 5),
(5, 'GANCICLOVIR', 2, 'Ganciclovir	500 mg *\r\n* par dose unitaire', 'Infection à Candida\r\nCandidose buccale\r\nInfection des voies respiratoires supérieures\r\nSepticémie\r\nGrippe\r\nInfection du tractus urinaire\r\nCellulite', 'Neutropénie < = 500/mm3\r\nThrombopénie < 25000/mm3\r\nHémoglobine < 8 g/dL\r\nInjection intraveineuse en bolus\r\nVoie IM\r\nVoie SC\r\nAbsence de contraception féminine efficace', 3),
(6, 'MAALOX', 13, 'Hydroxyde d\'aluminium	460 mg *\r\nHydroxyde de magnésium	400 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Hydroxyde d\'aluminium , Hydroxyde de magnésium\r\nExcipients : Saccharose sirop à 64 pour cent , Sorbitol liquide (non cristallisable) , Gomme xanthane , Gomme guar , Sodium chlorure , Arôme fruits rouges : Maltodextrine , Gomme arabique , Glycéryle triacétate , Maltol\r\nAucun excipient à effet notoire ? n\'est présent dans la composition de ce médicament', 'Réaction d\'hypersensibilité\r\nPrurit cutané\r\nErythème\r\nUrticaire allergique\r\nRéaction anaphylactique\r\nChoc anaphylactique\r\nHypermagnésémie', 'Hypersensibilité hydroxyde de magnésium\r\nHypersensibilité hydroxyde d\'aluminium\r\nInsuffisance rénale sévère\r\nIntolérance au fructose\r\nSyndrome de malabsorption du glucose\r\nSyndrome de malabsorption du galactose\r\nDéficit en sucrase-isomaltase', 4),
(7, 'SPASFON', 7, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Anémie\r\nAnémie non hémolytique\r\nDépression de la moelle osseuse\r\nThrombopénie\r\nLeucopénie\r\nNeutropénie\r\nOedème', 'Insuffisance hépatocellulaire sévère\r\nEnfant avant 6 ans\r\nConsommation d\'alcool\r\n·         Hypersensibilité à la substance active ou à l\'un des excipients mentionnés à la rubrique Composition.\r\n·         Insuffisance hépatocellulaire sévère.\r\n·         Enfant de moins de 6 ans, en raison des risques de fausse route.', 2),
(8, 'DAFLON', 4, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Céphalée\r\nSomnolence\r\nSécheresse de la bouche\r\nFatigue\r\nAsthénie\r\nDouleur abdominale\r\nDiarrhée', 'Hypersensibilité lévocétirizine\r\nHypersensibilité cétirizine\r\nHypersensibilité hydroxyzine\r\nHypersensibilité dérivés de la pipérazine\r\nInsuffisance rénale sévère (Clcr < 10 ml/min)\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose', 1),
(9, 'XANAX', 8, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Anémie\r\nAnémie non hémolytique\r\nDépression de la moelle osseuse\r\nThrombopénie\r\nLeucopénie\r\nNeutropénie\r\nOedème', 'Insuffisance hépatocellulaire sévère\r\nEnfant avant 6 ans\r\nConsommation d\'alcool\r\n·         Hypersensibilité à la substance active ou à l\'un des excipients mentionnés à la rubrique Composition.\r\n·         Insuffisance hépatocellulaire sévère.\r\n·         Enfant de moins de 6 ans, en raison des risques de fausse route.', 3),
(10, 'LEVOTHYROX', 2, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Somnolence\r\nCéphalée\r\nAugmentation de l\'appétit\r\nInsomnie\r\nNervosité\r\nFatigue\r\nRéaction d\'hypersensibilité', 'Enfant de moins de 30 kg\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose\r\nSyndrome de malabsorption du glucose\r\nSyndrome de malabsorption du galactose\r\nDéficit en lactase\r\nGrossesse', 2),
(11, 'IMODIUM', 11, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Céphalée\r\nSomnolence\r\nSécheresse de la bouche\r\nFatigue\r\nAsthénie\r\nDouleur abdominale\r\nDiarrhée', 'Hypersensibilité lévocétirizine\r\nHypersensibilité cétirizine\r\nHypersensibilité hydroxyzine\r\nHypersensibilité dérivés de la pipérazine\r\nInsuffisance rénale sévère (Clcr < 10 ml/min)\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose', 1),
(12, 'KARDEGIC', 10, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Somnolence\r\nCéphalée\r\nAugmentation de l\'appétit\r\nInsomnie\r\nNervosité\r\nFatigue\r\nRéaction d\'hypersensibilité', 'Enfant de moins de 30 kg\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose\r\nSyndrome de malabsorption du glucose\r\nSyndrome de malabsorption du galactose\r\nDéficit en lactase\r\nGrossesse', 3),
(13, 'ISIMIG', 7, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Somnolence\r\nCéphalée\r\nAugmentation de l\'appétit\r\nInsomnie\r\nNervosité\r\nFatigue\r\nRéaction d\'hypersensibilité', 'Enfant de moins de 30 kg\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose\r\nSyndrome de malabsorption du glucose\r\nSyndrome de malabsorption du galactose\r\nDéficit en lactase\r\nGrossesse', 3),
(14, 'TAHOR', 9, 'Paracétamol	500 mg *\r\n* par dose unitaire\r\nPrincipes actifs : Paracétamol\r\nExcipients : Amidon de riz , Glycérol distéarate , Magnésium stéarate , Composition de l\'enveloppe de la gélule : Gélatine , Titane dioxyde , Jaune de quinoléine , Fer oxyde rouge , Bleu patenté V', 'Somnolence\r\nCéphalée\r\nAugmentation de l\'appétit\r\nInsomnie\r\nNervosité\r\nFatigue\r\nRéaction d\'hypersensibilité', 'Hypersensibilité lévocétirizine\r\nHypersensibilité cétirizine\r\nHypersensibilité hydroxyzine\r\nHypersensibilité dérivés de la pipérazine\r\nInsuffisance rénale sévère (Clcr < 10 ml/min)\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose', 5),
(15, 'PIVALONE', 7, 'Cétylpyridinium -N chlorure, Sodium chlorure, Phosphate monosodique, Sodium hydroxyde soluté officinal, Eau purifiée', 'Picotement nasal\r\nSécheresse de la muqueuse nasale\r\nOedème cutanéomuqueux de la face\r\nCataracte\r\nGlaucome\r\nSyndrome de Cushing\r\nSyndrome cushingoïde', 'Hypersensibilité tixocortol\r\nInfection ORL virale\r\nInfection ORL fongique\r\nEpistaxis\r\nHypersensibilité à la substance active ou à l\'un des excipients mentionnés à la rubrique Composition.\r\n\r\nEpistaxis.\r\n\r\nPIVALONE ne doit pas être utilisé en présence d\'une infection virale localisée impliquant la muqueuse nasale, telle que Herpès simplex.\r\n\r\nPIVALONE ne doit pas être utilisé en présence d\'une infection fongique locale, telle que la candidose.\r\n\r\nEn raison de l\'effet inhibiteur des corticostéroïdes sur la cicatrisation des plaies, les patients qui ont subi une intervention chirurgicale ou un traumatisme nasal récent, ne doivent pas utiliser PIVALONE jusqu\'à la guérison.', 2),
(16, 'VASTAREL', 11, ' Calcium hydrogénophosphate dihydraté , Hypromellose , Povidone , Silice colloïdale anhydre , Magnésium stéarate , Pelliculage : Titane dioxyde , Glycérol , Hypromellose , Macrogol 6000 , Fer oxyde rouge , Magnésium stéarate', 'Vertige\r\nCéphalée\r\nSyndrome Parkinsonien\r\nTremblement de type parkinsonien\r\nAkinésie\r\nHypertonie\r\nInstabilité posturale', 'Hypersensibilité trimétazidine\r\nEnfant de moins de 18 ans\r\nMaladie de Parkinson\r\nSyndrome Parkinsonien\r\nTremblement\r\nSyndrome des jambes sans repos', 3),
(17, 'ADVIL', 6, 'Amidon de maïs , Amidon prégélatinisé , Silice colloïdale anhydre , Stéarique acide , Saccharose , Amidon de pomme de terre oxydé (Perfectamyl gel 45) , Povidone , Polysorbate 80 , Macrogol 6000 , Titane dioxyde , Calcium carbonate , Talc , Cire de carnauba , Fer oxyde rouge , Encre noire Opacode S-1-17823 : Gomme laque , Fer oxyde noir , N-butylalcool , Eau purifiée , Propylène glycol , Isopropylique alcool , Ammonium hydroxyde', 'Infarctus du myocarde\r\nAVC\r\nUlcère peptique\r\nPerforation gastro-intestinale\r\nHémorragie gastro-intestinale\r\nNausée\r\nVomissement', 'Antécédent d\'asthme déclenché par la prise d\'ibuprofène\r\nAntécédent d\'asthme déclenché par la prise d\'AINS\r\nAntécédent d\'asthme déclenché par la prise d\'aspirine\r\nAntécédent d\'hémorragie ou de perforation digestive par AINS\r\nHémorragie gastro-intestinale\r\nHémorragie cérébrovasculaire\r\nSaignement évolutif cliniquement significatif', 6),
(18, 'AUGMENTIN', 9, 'Présence de : Potassium, Sodium', 'Candidose cutanéomuqueuse\r\nRésistance bactérienne\r\nLeucopénie\r\nNeutropénie\r\nThrombocytopénie\r\nAgranulocytose\r\nAnémie hémolytique', 'Hypersensibilité pénicillines\r\nAllergie bêtalactamines\r\nAntécédent d\'atteinte hépatique liée à l\'association amoxicilline/acide clavulanique\r\nMononucléose infectieuse\r\nGrossesse', 3),
(19, 'DIAMICRON', 4, 'Maltodextrine, Hypromellose, Magnésium stéarate, Silice colloïdale anhydre', 'Hypoglycémie\r\nCéphalée\r\nFaim intense\r\nNausée\r\nVomissement\r\nFatigue\r\nTrouble du sommeil', 'Diabète de type 1\r\nPrécoma diabétique\r\nComa diabétique\r\nAcidocétose diabétique\r\nInsuffisance rénale sévère\r\nInsuffisance hépatique sévère\r\nAllaitement', 2),
(20, 'XYZALL', 4, 'Cellulose microcristalline, Silice colloïdale anhydre, Magnésium stéarate, Opadry Y-1-7000 : Hypromellose, Titane dioxyde, Macrogol 400', 'Céphalée\r\nSomnolence\r\nSécheresse de la bouche\r\nFatigue\r\nAsthénie\r\nDouleur abdominale\r\nDiarrhée', 'Hypersensibilité lévocétirizine\r\nHypersensibilité cétirizine\r\nHypersensibilité hydroxyzine\r\nHypersensibilité dérivés de la pipérazine\r\nInsuffisance rénale sévère (Clcr < 10 ml/min)\r\nEnfant de moins de 6 ans\r\nIntolérance au galactose', 2),
(21, 'CODEINE', 2, 'Paracetamole', 'Somnolence, Fatigue, Vomissement', 'asthme, insuffisance respiratoire ', 18);

-- --------------------------------------------------------

--
-- Structure de la table `prescrire`
--

DROP TABLE IF EXISTS `prescrire`;
CREATE TABLE IF NOT EXISTS `prescrire` (
  `MED_DEPOTLEGAL` int(11) NOT NULL,
  `TIN_CODE` int(11) NOT NULL,
  `DOS_CODE` int(11) NOT NULL,
  `PRE_POSOLOGIE` varchar(40) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`MED_DEPOTLEGAL`,`TIN_CODE`,`DOS_CODE`),
  KEY `MED_DEPOTLEGAL` (`MED_DEPOTLEGAL`,`TIN_CODE`),
  KEY `TIN_CODE` (`TIN_CODE`),
  KEY `DOS_CODE` (`DOS_CODE`),
  KEY `MED_DEPOTLEGAL_2` (`MED_DEPOTLEGAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `prescrire`
--

INSERT INTO `prescrire` (`MED_DEPOTLEGAL`, `TIN_CODE`, `DOS_CODE`, `PRE_POSOLOGIE`) VALUES
(1, 1, 1, '10x par jour pendant 8ans');

-- --------------------------------------------------------

--
-- Structure de la table `type_individu`
--

DROP TABLE IF EXISTS `type_individu`;
CREATE TABLE IF NOT EXISTS `type_individu` (
  `TIN_CODE` int(11) NOT NULL AUTO_INCREMENT,
  `TIN_LIBELLE` char(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`TIN_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `type_individu`
--

INSERT INTO `type_individu` (`TIN_CODE`, `TIN_LIBELLE`) VALUES
(1, 'Adulte'),
(2, 'Jeune adulte'),
(3, 'Enfant'),
(4, 'Jeune enfant'),
(5, 'Nourrisson');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `interagir`
--
ALTER TABLE `interagir`
  ADD CONSTRAINT `interagir_ibfk_1` FOREIGN KEY (`MED_PERTURBATEUR`) REFERENCES `medicament` (`MED_DEPOTLEGAL`),
  ADD CONSTRAINT `interagir_ibfk_2` FOREIGN KEY (`MED_MED_PERTURBE`) REFERENCES `medicament` (`MED_DEPOTLEGAL`);

--
-- Contraintes pour la table `medicament`
--
ALTER TABLE `medicament`
  ADD CONSTRAINT `medicament_ibfk_1` FOREIGN KEY (`FAM_COD`) REFERENCES `famille` (`FAM_CODE`);

--
-- Contraintes pour la table `prescrire`
--
ALTER TABLE `prescrire`
  ADD CONSTRAINT `prescrire_ibfk_1` FOREIGN KEY (`MED_DEPOTLEGAL`) REFERENCES `medicament` (`MED_DEPOTLEGAL`),
  ADD CONSTRAINT `prescrire_ibfk_2` FOREIGN KEY (`TIN_CODE`) REFERENCES `type_individu` (`TIN_CODE`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
