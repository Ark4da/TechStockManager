-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 23, 2025 at 01:13 PM
-- Server version: 5.7.24
-- PHP Version: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `computeruniverse`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_customer`
--

CREATE TABLE `admin_customer` (
  `ID` int(11) NOT NULL,
  `store_name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `delivery_address` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin_customer`
--

INSERT INTO `admin_customer` (`ID`, `store_name`, `Email`, `phone`, `delivery_address`) VALUES
(1, 'Oleksiy Ivanenko', 'ivanenko.oleksiy@example.com', '+380501234567', '12 Shevchenka St., Kyiv'),
(2, 'Natalia Petrenko', 'petrenko.natalia@example.com', '+380931234567', '8 Lesi Ukrainky St., Lviv'),
(3, 'Mykyta Kovalenko', 'dsadfa@gmail.com', '+380979770727', '6 Musorgsky St., Kryvyi Rih'),
(4, 'Oleksiy Petrenko', 'fsdfs@gmail.com', '+380129312', 'Musorgsky St.'),
(5, 'User', 'user@gmail.com', '+380112312', 'vulicha');

-- --------------------------------------------------------

--
-- Table structure for table `admin_manufacturer`
--

CREATE TABLE `admin_manufacturer` (
  `ID` int(11) NOT NULL,
  `manufacturer_name` varchar(255) NOT NULL,
  `country` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin_manufacturer`
--

INSERT INTO `admin_manufacturer` (`ID`, `manufacturer_name`, `country`) VALUES
(1, 'Intel', 'USA'),
(2, 'AMD', 'USA'),
(3, 'NVIDIA', 'USA'),
(4, 'ASUS', 'Taiwan'),
(5, 'MSI', 'Taiwan'),
(6, 'Gigabyte', 'Taiwan'),
(7, 'AsRock', 'Taiwan'),
(8, 'Corsair', 'USA'),
(9, 'Kingston', 'USA'),
(10, 'G.Skill', 'Taiwan'),
(11, 'Samsung', 'South Korea'),
(12, 'Crucial', 'USA'),
(13, 'Aerocool', 'USA'),
(14, 'Deepcool', 'China'),
(15, 'NZXT', 'USA'),
(16, 'Be Quiet!', 'Germany'),
(17, 'Arctic', 'USA'),
(18, 'Seagate', 'USA');

-- --------------------------------------------------------

--
-- Table structure for table `admin_order`
--

CREATE TABLE `admin_order` (
  `ID` int(11) NOT NULL,
  `department` varchar(50) DEFAULT NULL,
  `order_id` int(11) DEFAULT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `delivery_date` date DEFAULT NULL,
  `items` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin_order`
--

INSERT INTO `admin_order` (`ID`, `department`, `order_id`, `customer_id`, `order_date`, `total_amount`, `status`, `delivery_date`, `items`) VALUES
(2, 'mobile', 2, 1, '2025-03-25 10:24:39', '35999.00', 'fsd', '2025-10-10', '(2) iPhone 14 Pro'),
(4, 'computer', 1, 1, '2025-03-25 14:54:10', '26676.00', 'fsdf', '2025-03-25', '(7) MSI GeForce RTX 4060, (3) Intel Core i5-12400F, (32) Case NZXT H6 Flow Black, (22) Kingston DDR4 8GB 3200Mhz FURY Beast Black'),
(5, 'television', 1, 1, '2025-03-13 12:03:27', '12435.00', 'dfs', '2025-10-10', NULL),
(6, 'computer', 2, 1, '2025-04-18 14:54:56', '19954.00', 'dasdasd', '2025-04-18', '(6) Intel Core i5-13400F, (22) Kingston DDR4 8GB 3200Mhz FURY Beast Black'),
(7, 'television', 2, 1, '2025-04-18 15:41:16', '79999.00', 'dsa', '2025-04-18', '(3) LG 65\" OLED 8K TV'),
(8, 'audio', 1, 1, '2025-04-18 15:46:54', '8998.00', 'dwads', '2025-04-18', '(3) JBL Charge 5'),
(9, 'mobile', 1, 1, '2025-03-13 11:50:01', '1000.00', 'dsad', '2025-10-10', '');

-- --------------------------------------------------------

--
-- Table structure for table `admin_payment`
--

CREATE TABLE `admin_payment` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `department` varchar(50) NOT NULL,
  `payment_method` varchar(100) NOT NULL,
  `payment_amount` decimal(10,2) NOT NULL,
  `payment_date` date NOT NULL,
  `payment_status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin_payment`
--

INSERT INTO `admin_payment` (`ID`, `order_id`, `department`, `payment_method`, `payment_amount`, `payment_date`, `payment_status`) VALUES
(3, 2, 'mobile', 'czxc', '35999.00', '2025-04-16', 'zxc'),
(4, 1, 'computer', 'das', '26676.00', '2025-04-18', 'dasd'),
(5, 1, 'television', 'dsa', '0.00', '2025-04-18', 'asd'),
(9, 2, 'computer', 'dsa', '19954.00', '2025-04-18', 'da'),
(12, 2, 'television', 'asd', '79999.00', '2025-04-18', 'fdsfs'),
(13, 1, 'audio', 'dsa', '8998.00', '2025-04-18', 'das');

-- --------------------------------------------------------

--
-- Table structure for table `admin_product`
--

CREATE TABLE `admin_product` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `manufacturer_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) DEFAULT NULL,
  `description` text,
  `date_added` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin_product`
--

INSERT INTO `admin_product` (`ID`, `name`, `category_id`, `manufacturer_id`, `price`, `stock_quantity`, `description`, `date_added`) VALUES
(1, 'AMD Ryzen 5 7500F', 1, 2, '7849.00', 2, 'Processor AMD Ryzen 5 7500F 3.7(5.0)GHz 32MB sAM5 Tray (100-000000597)', '2024-10-15'),
(2, 'AMD Ryzen 7 7800X3D', 1, 2, '21699.00', 16, 'Processor AMD Ryzen 7 7800X3D 4.2(5.0)GHz 96MB sAM5 Box (100-100000910WOF)', '2024-10-15'),
(3, 'Intel Core i5-12400F', 1, 1, '5339.00', 34, 'Processor Intel Core i5-12400F 2.5(4.4)GHz 18MB s1700 Box (BX8071512400F)', '2024-10-15'),
(4, 'AMD Ryzen 7 5700X3D', 1, 2, '9499.00', 8, 'Processor AMD Ryzen 7 5700X3D 3.0(4.1)GHz 96MB sAM4 Tray (100-000001503)', '2024-11-05'),
(5, 'AMD Ryzen 7 7700', 1, 2, '11399.00', 6, 'Processor AMD Ryzen 7 7700 3.8(5.3)GHz 32MB sAM5 Multipack (100-100000592MPK)', '2024-10-15'),
(6, 'Intel Core i5-13400F', 1, 1, '8299.00', 10, 'Processor Intel Core i5-13400F 2.5(4.6)GHz 20MB s1700 Box (BX8071513400F)', '2024-10-15'),
(7, 'MSI GeForce RTX 4060', 2, 5, '14199.00', 15, 'Graphics Card MSI GeForce RTX 4060 VENTUS 2X BLACK OC 8192MB (RTX 4060 VENTUS 2X BLACK 8G OC)', '2024-10-15'),
(8, 'MSI GeForce RTX 4070 Ti SUPER', 2, 5, '45899.00', 0, 'Graphics Card MSI GeForce RTX 4070 Ti SUPER GAMING SLIM Stalker 2 Edition 16384MB (RTX 4070 Ti SUPER 16G GAMING SLIM STALKER 2 EDITION)', '2024-10-15'),
(9, 'Gigabyte GeForce RTX 3060', 2, 6, '12599.00', 15, 'Graphics Card Gigabyte GeForce RTX 3060 WindForce OC 12228MB (GV-N3060WF2OC-12GD 2.0)', '2024-10-15'),
(10, 'Gigabyte GeForce RTX 4060', 2, 6, '14099.00', 3, 'Graphics Card Gigabyte GeForce RTX 4060 Windforce OC 8192MB (GV-N4060WF2OC-8GD)', '2024-10-15'),
(11, 'Asus TUF GeForce RTX 4090', 2, 4, '62999.00', 0, 'Graphics Card Asus TUF GeForce RTX 4090 Gaming OG OC 24576MB (TUF-RTX4090-O24G-OG-GAMING FR) Factory Recertified', '2024-10-15'),
(12, 'Asus ROG Strix GeForce RTX 4090', 2, 4, '65999.00', 0, 'Graphics Card Asus ROG Strix GeForce RTX 4090 OC 24576MB (ROG-STRIX-RTX4090-O24G-GAMING FR) Factory Recertified', '2024-10-15'),
(13, 'MSI B450M-A', 3, 5, '2649.00', 10, 'Motherboard MSI B450M-A PRO MAX (sAM4, AMD B450)', '2024-10-15'),
(14, 'Gigabyte B550M', 3, 6, '4399.00', 27, 'Motherboard Gigabyte B550M AORUS ELITE (sAM4, AMD B550)', '2024-10-15'),
(15, 'Gigabyte B650M', 3, 6, '7699.00', 19, 'Motherboard Gigabyte B650M GAMING X AX (sAM5, AMD B650)', '2024-10-15'),
(16, 'Gigabyte B550', 3, 6, '4999.00', 14, 'Motherboard Gigabyte B550 GAMING X V2 (sAM4, AMD B550)', '2024-10-15'),
(17, 'MSI PRO B650-S', 3, 5, '6799.00', 8, 'Motherboard MSI PRO B650-S WIFI (sAM5, AMD B650)', '2024-10-15'),
(18, 'MSI B760', 3, 5, '6859.00', 55, 'Motherboard MSI B760 GAMING PLUS WIFI (s1700, Intel B760)', '2024-10-15'),
(19, 'Kingston DDR4 16GB (2x8GB) 3200Mhz FURY Beast Black', 4, 9, '1627.00', 94, 'RAM Kingston DDR4 16GB (2x8GB) 3200Mhz FURY Beast Black (KF432C16BBK2/16)', '2024-10-16'),
(20, 'Kingston DDR5 32GB (2x16GB) 6000Mhz FURY Beast Black', 4, 9, '5199.00', 17, 'RAM Kingston DDR5 32GB (2x16GB) 6000Mhz FURY Beast Black (KF560C40BBK2-32)', '2024-10-16'),
(21, 'Kingston DDR4 32GB (2x16GB) 3200Mhz FURY Beast Black', 4, 9, '3069.00', 40, 'RAM Kingston DDR4 32GB (2x16GB) 3200Mhz FURY Beast Black (KF432C16BB1K2/32)', '2024-10-16'),
(22, 'Kingston DDR4 8GB 3200Mhz FURY Beast Black', 4, 9, '839.00', 5, 'RAM Kingston DDR4 8GB 3200Mhz FURY Beast Black (KF432C16BB/8)', '2024-10-16'),
(23, 'Corsair DDR4 16GB (2x8GB) 3600Mhz Vengeance LPX Black', 4, 8, '1849.00', 11, 'RAM Corsair DDR4 16GB (2x8GB) 3600Mhz Vengeance LPX Black (CMK16GX4M2D3600C16)', '2024-10-16'),
(24, 'G.Skill DDR4 16GB (2x8GB) 3200Mhz Ripjaws V', 4, 10, '1340.00', 28, 'RAM G.Skill DDR4 16GB (2x8GB) 3200Mhz Ripjaws V (F4-3200C16D-16GVKB)', '2024-10-16'),
(25, 'HDD Seagate BarraCuda 1TB', 5, 18, '2175.00', 22, 'HDD Seagate BarraCuda 1TB 64MB 7200RPM 3.5\" (ST1000DM010)', '2024-10-16'),
(26, 'HDD Seagate BarraCuda 2TB', 5, 18, '2599.00', 22, 'HDD Seagate BarraCuda 2TB 256MB 7200RPM 3.5\" (ST2000DM008)', '2024-10-16'),
(27, 'SSD Kingston KC3000 3D NAND TLC 1TB M.2', 6, 9, '4119.00', 28, 'SSD Kingston KC3000 3D NAND TLC 1TB M.2 (2280 PCI-E) NVMe x4 (SKC3000S/1024G)', '2024-10-16'),
(28, 'SSD Samsung 970 Evo Plus V-NAND MLC 1TB M.2', 6, 11, '4199.00', 13, 'SSD Samsung 970 Evo Plus V-NAND MLC 1TB M.2 (2280 PCI-E) (MZ-V7S1T0BW)', '2024-10-16'),
(29, 'Power Supply Deepcool PF700 700W', 7, 14, '2449.00', 2, 'Power Supply Deepcool PF700 700W (R-PF700D-HA0B-EU)', '2024-10-16'),
(30, 'Power Supply Be Quiet! Pure Power 12 M 850W', 7, 16, '5999.00', 7, 'Power Supply Be Quiet! Pure Power 12 M 850W (BN344)', '2024-10-16'),
(31, 'Case MSI MAG FORGE M100R Black', 8, 5, '1999.00', 9, 'Case MSI MAG FORGE M100R without PSU Black', '2024-10-16'),
(32, 'Case NZXT H6 Flow Black', 8, 15, '6299.00', 1, 'Case NZXT H6 Flow without PSU (CC-H61FB-01) Black', '2024-10-16'),
(33, 'Case Deepcool CH780 Tempered Glass', 8, 14, '6999.00', 0, 'Case Deepcool CH780 Tempered Glass without PSU (R-CH780-WHADE41-G-1) White', '2024-10-16'),
(34, 'Cooler Deepcool AK400 DIGITAL Black', 9, 14, '2049.00', 8, 'Cooler Deepcool AK400 DIGITAL (R-AK400-BKADMN-G) Black', '2024-10-16'),
(35, 'Cooler Be Quiet! Dark Rock 4', 9, 16, '2899.00', 30, 'Cooler Be Quiet! Dark Rock 4 (BK021)', '2024-10-16'),
(36, 'AIO Liquid Cooler Arctic Liquid Freezer III Black', 9, 17, '4699.00', 0, 'AIO Liquid Cooler Arctic Liquid Freezer III 360 (ACFRE00136A) Black', '2024-10-16'),
(37, 'AIO Liquid Cooler Be Quiet! Silent Loop 2', 9, 16, '7099.00', 1, 'AIO Liquid Cooler Be Quiet! Silent Loop 2 360mm (BW012)', '2024-10-16'),
(38, 'Case Fan Be Quiet! Pure Wings 2', 10, 16, '399.00', 27, 'Case Fan Be Quiet! Pure Wings 2 120mm PWM (BL039)', '2024-10-16'),
(39, 'GPU Support Bracket Deepcool', 10, 14, '409.00', 6, 'GPU Support Bracket Deepcool GH-01', '2024-10-16'),
(40, 'Thermal Paste Arctic MX-4 4g', 10, 17, '199.00', 24, 'Thermal Paste Arctic MX-4 4g (ACTCP00002B)', '2024-10-16');

-- --------------------------------------------------------

--
-- Table structure for table `admin_productcategory`
--

CREATE TABLE `admin_productcategory` (
  `ID` int(11) NOT NULL,
  `category_name` varchar(255) NOT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin_productcategory`
--

INSERT INTO `admin_productcategory` (`ID`, `category_name`, `description`) VALUES
(1, 'Processors', 'Product category containing various types of processors'),
(2, 'Graphics Cards', 'Product category containing graphics cards for PC'),
(3, 'Motherboards', 'Product category containing motherboards'),
(4, 'RAM', 'Product category containing RAM'),
(5, 'Hard Drives', 'Product category containing hard drives'),
(6, 'SSD', 'Product category containing solid-state drives'),
(7, 'Power Supply Units', 'Product category containing power supply units'),
(8, 'Cases', 'Product category containing cases'),
(9, 'Cooling Systems', 'Product category containing cooling systems'),
(10, 'Assembly Accessories', '');

-- --------------------------------------------------------

--
-- Table structure for table `audio_customer`
--

CREATE TABLE `audio_customer` (
  `ID` int(100) NOT NULL,
  `store_name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `delivery_address` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `audio_customer`
--

INSERT INTO `audio_customer` (`ID`, `store_name`, `Email`, `phone`, `delivery_address`) VALUES
(1, 'dsada', 'dasa', '312', 'das');

-- --------------------------------------------------------

--
-- Table structure for table `audio_manufacturer`
--

CREATE TABLE `audio_manufacturer` (
  `ID` int(11) NOT NULL,
  `manufacturer_name` varchar(255) NOT NULL,
  `country` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `audio_manufacturer`
--

INSERT INTO `audio_manufacturer` (`ID`, `manufacturer_name`, `country`) VALUES
(1, 'Sony', 'Japan'),
(2, 'Bose', 'USA'),
(3, 'Sennheiser', 'Germany'),
(4, 'JBL', 'USA'),
(5, 'Beats', 'USA'),
(6, 'Audio-Technica', 'Japan'),
(7, 'Bang & Olufsen', 'Denmark'),
(8, 'Harman Kardon', 'USA'),
(9, 'Pioneer', 'Japan'),
(10, 'Marshall', 'United Kingdom');

-- --------------------------------------------------------

--
-- Table structure for table `audio_order`
--

CREATE TABLE `audio_order` (
  `ID` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `delivery_date` date DEFAULT NULL,
  `items` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `audio_order`
--

INSERT INTO `audio_order` (`ID`, `customer_id`, `order_date`, `total_amount`, `status`, `delivery_date`, `items`) VALUES
(1, 1, '2025-04-18 15:46:54', '8998.00', 'dwads', '2025-04-18', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `audio_order_details`
--

CREATE TABLE `audio_order_details` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `audio_order_details`
--

INSERT INTO `audio_order_details` (`ID`, `order_id`, `product_id`, `quantity`, `price`) VALUES
(1, 1, 3, 2, '8998.00');

-- --------------------------------------------------------

--
-- Table structure for table `audio_payment`
--

CREATE TABLE `audio_payment` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `payment_method` varchar(50) NOT NULL,
  `payment_amount` decimal(10,2) NOT NULL,
  `payment_date` datetime DEFAULT NULL,
  `payment_status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `audio_product`
--

CREATE TABLE `audio_product` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `manufacturer_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) DEFAULT NULL,
  `description` text,
  `date_added` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `audio_product`
--

INSERT INTO `audio_product` (`ID`, `name`, `category_id`, `manufacturer_id`, `price`, `stock_quantity`, `description`, `date_added`) VALUES
(1, 'Sony WH-1000XM5', 1, 1, '8499.00', 25, 'Wireless over-ear headphones with active noise cancellation Sony WH-1000XM5.', '2024-03-15'),
(2, 'Bose QuietComfort 45', 1, 2, '7999.00', 30, 'Bose QuietComfort 45 headphones with active noise cancellation for comfortable listening.', '2024-03-15'),
(3, 'JBL Charge 5', 2, 4, '4499.00', 48, 'JBL Charge 5 portable speaker with powerful sound and waterproof body.', '2024-03-15'),
(4, 'Sennheiser Momentum 3', 1, 3, '12999.00', 15, 'Sennheiser Momentum 3 wireless over-ear headphones with noise cancellation.', '2024-03-15'),
(5, 'Marshall Kilburn II', 2, 8, '7999.00', 20, 'Marshall Kilburn II portable speaker with powerful sound and retro design.', '2024-03-15'),
(6, 'Audio-Technica ATH-M50X', 1, 7, '6599.00', 35, 'Audio-Technica ATH-M50X headphones with excellent sound quality for professionals.', '2024-03-15'),
(7, 'Beats Studio 3 Wireless', 1, 5, '10999.00', 18, 'Beats Studio 3 wireless over-ear headphones with active noise cancellation.', '2024-03-15'),
(8, 'Bang & Olufsen Beoplay A1', 2, 6, '11999.00', 10, 'Bang & Olufsen Beoplay A1 portable speaker with refined design.', '2024-03-15'),
(9, 'Harman Kardon Onyx Studio 6', 2, 9, '13999.00', 8, 'Harman Kardon Onyx Studio 6 portable speaker with luxurious sound and design.', '2024-03-15'),
(10, 'Pioneer DJ HDJ-X10', 1, 10, '17999.00', 12, 'Pioneer DJ HDJ-X10 professional headphones with excellent sound quality for DJs.', '2024-03-15');

-- --------------------------------------------------------

--
-- Table structure for table `audio_productcategory`
--

CREATE TABLE `audio_productcategory` (
  `ID` int(11) NOT NULL,
  `category_name` varchar(255) NOT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `audio_productcategory`
--

INSERT INTO `audio_productcategory` (`ID`, `category_name`, `description`) VALUES
(1, 'Headphones', 'Product category containing various types of headphones, including in-ear, on-ear and over-ear.'),
(2, 'Speakers', 'Product category containing various types of speakers, including portable, home and professional audio systems.'),
(3, 'Audio Interfaces', 'Product category containing audio interfaces for recording and sound processing, including USB and analog options.'),
(4, 'Microphones', 'Product category containing various types of microphones for studio recording, podcasts and video.'),
(5, 'Sound Cards', 'Product category containing sound cards for improved audio quality in computers and studio systems.'),
(6, 'Amplifiers', 'Product category containing amplifiers for audio systems to improve sound power.'),
(7, 'Portable Audio Systems', 'Product category containing compact audio systems for playing music anywhere.'),
(8, 'Car Audio Systems', 'Product category containing car audio equipment, including speakers and amplifiers.'),
(9, 'Cables and Accessories', 'Product category containing various cables, adapters and accessories for connecting audio equipment.'),
(10, 'Home Theater Systems', 'Product category containing audio-video systems for creating a home theater with high-quality sound.');

-- --------------------------------------------------------

--
-- Table structure for table `computer_customer`
--

CREATE TABLE `computer_customer` (
  `ID` int(100) NOT NULL,
  `store_name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `delivery_address` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `computer_customer`
--

INSERT INTO `computer_customer` (`ID`, `store_name`, `Email`, `phone`, `delivery_address`) VALUES
(1, 'Tech-Center', 'contact@techcenter.com', '0987654321', '10 Technical St.');

-- --------------------------------------------------------

--
-- Table structure for table `computer_manufacturer`
--

CREATE TABLE `computer_manufacturer` (
  `ID` int(11) NOT NULL,
  `manufacturer_name` varchar(255) NOT NULL,
  `country` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `computer_manufacturer`
--

INSERT INTO `computer_manufacturer` (`ID`, `manufacturer_name`, `country`) VALUES
(1, 'Intel', 'USA'),
(2, 'AMD', 'USA'),
(3, 'NVIDIA', 'USA'),
(4, 'ASUS', 'Taiwan'),
(5, 'MSI', 'Taiwan'),
(6, 'Gigabyte', 'Taiwan'),
(7, 'AsRock', 'Taiwan'),
(8, 'Corsair', 'USA'),
(9, 'Kingston', 'USA'),
(10, 'G.Skill', 'Taiwan'),
(11, 'Samsung', 'South Korea'),
(12, 'Crucial', 'USA'),
(13, 'Aerocool', 'USA'),
(14, 'Deepcool', 'China'),
(15, 'NZXT', 'USA'),
(16, 'Be Quiet!', 'Germany'),
(17, 'Arctic', 'USA'),
(18, 'Seagate', 'USA');

-- --------------------------------------------------------

--
-- Table structure for table `computer_order`
--

CREATE TABLE `computer_order` (
  `ID` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `delivery_date` date DEFAULT NULL,
  `items` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `computer_order`
--

INSERT INTO `computer_order` (`ID`, `customer_id`, `order_date`, `total_amount`, `status`, `delivery_date`, `items`) VALUES
(1, 1, '2025-03-25 14:54:10', '26676.00', 'Processing', '2025-03-25', NULL),
(2, 1, '2025-04-18 14:54:56', '19954.00', 'Processing', '2025-04-18', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `computer_order_details`
--

CREATE TABLE `computer_order_details` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `computer_order_details`
--

INSERT INTO `computer_order_details` (`ID`, `order_id`, `product_id`, `quantity`, `price`) VALUES
(1, 1, 3, 1, '5339.00'),
(2, 1, 7, 1, '14199.00'),
(3, 1, 22, 1, '839.00'),
(4, 1, 32, 1, '6299.00'),
(5, 2, 22, 4, '3356.00'),
(6, 2, 6, 2, '16598.00');

-- --------------------------------------------------------

--
-- Table structure for table `computer_payment`
--

CREATE TABLE `computer_payment` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `payment_method` varchar(50) NOT NULL,
  `payment_amount` decimal(10,2) NOT NULL,
  `payment_date` datetime DEFAULT NULL,
  `payment_status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `computer_product`
--

CREATE TABLE `computer_product` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `manufacturer_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) DEFAULT NULL,
  `description` text,
  `date_added` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `computer_product`
--

INSERT INTO `computer_product` (`ID`, `name`, `category_id`, `manufacturer_id`, `price`, `stock_quantity`, `description`, `date_added`) VALUES
(1, 'AMD Ryzen 5 7500F', 1, 2, '7849.00', 2, 'Processor AMD Ryzen 5 7500F 3.7(5.0)GHz 32MB sAM5 T...', '2024-10-15'),
(2, 'AMD Ryzen 7 7800X3D', 1, 2, '21699.00', 16, 'Processor AMD Ryzen 7 7800X3D 4.2(5.0)GHz 96MB sAM5...', '2024-10-15'),
(3, 'Intel Core i5-12400F', 1, 1, '5339.00', 33, 'Processor Intel Core i5-12400F 2.5(4.4)GHz 18MB s17...', '2024-10-15'),
(4, 'AMD Ryzen 7 5700X3D', 1, 2, '9499.00', 8, 'Processor AMD Ryzen 7 5700X3D 3.0(4.1)GHz 96MB sAM4...', '2024-11-05'),
(5, 'AMD Ryzen 7 7700', 1, 2, '11399.00', 6, 'Processor AMD Ryzen 7 7700 3.8(5.3)GHz 32MB sAM5 Mu...', '2024-10-15'),
(6, 'Intel Core i5-13400F', 1, 1, '8299.00', 8, 'Processor Intel Core i5-13400F 2.5(4.6)GHz 20MB s17...', '2024-10-15'),
(7, 'MSI GeForce RTX 4060', 2, 5, '14199.00', 14, 'Graphics Card MSI GeForce RTX 4060 VENTUS 2X BLACK OC...', '2024-10-15'),
(8, 'MSI GeForce RTX 4070 Ti SUPER', 2, 5, '45899.00', 0, 'Graphics Card MSI GeForce RTX 4070 Ti SUPER GAMING SL...', '2024-10-15'),
(9, 'Gigabyte GeForce RTX 3060', 2, 6, '12599.00', 15, 'Graphics Card Gigabyte GeForce RTX 3060 WindForce OC ...', '2024-10-15'),
(10, 'Gigabyte GeForce RTX 4060', 2, 6, '14099.00', 3, 'Graphics Card Gigabyte GeForce RTX 4060 Windforce OC ...', '2024-10-15'),
(11, 'Asus TUF GeForce RTX 4090', 2, 4, '62999.00', 0, 'Graphics Card Asus TUF GeForce RTX 4090 Gaming OG OC ...', '2024-10-15'),
(12, 'Asus ROG Strix GeForce RTX 4090', 2, 4, '65999.00', 0, 'Graphics Card Asus ROG Strix GeForce RTX 4090 OC 2457...', '2024-10-15'),
(13, 'MSI B450M-A', 3, 5, '2649.00', 10, 'Motherboard MSI B450M-A PRO MAX (sAM4, AMD B...', '2024-10-15'),
(14, 'Gigabyte B550M', 3, 6, '4399.00', 27, 'Motherboard Gigabyte B550M AORUS ELITE (sAM4...', '2024-10-15'),
(15, 'Gigabyte B650M', 3, 6, '7699.00', 19, 'Motherboard Gigabyte B650M GAMING X AX (sAM5...', '2024-10-15'),
(16, 'Gigabyte B550', 3, 6, '4999.00', 14, 'Motherboard Gigabyte B550 GAMING X V2 (sAM4,...', '2024-10-15'),
(17, 'MSI PRO B650-S', 3, 5, '6799.00', 8, 'Motherboard MSI PRO B650-S WIFI (sAM5, AMD B...', '2024-10-15'),
(18, 'MSI B760', 3, 5, '6859.00', 55, 'Motherboard MSI B760 GAMING PLUS WIFI (s1700...', '2024-10-15'),
(19, 'Kingston DDR4 16GB (2x8GB) 3200Mhz FURY Beast Blac...', 4, 9, '1627.00', 94, 'RAM Kingston DDR4 16GB (2x8GB) 3200Mhz FURY Beast ...', '2024-10-16'),
(20, 'Kingston DDR5 32GB (2x16GB) 6000Mhz FURY Beast Bla...', 4, 9, '5199.00', 17, 'RAM Kingston DDR5 32GB (2x16GB) 6000Mhz FURY Beast...', '2024-10-16'),
(21, 'Kingston DDR4 32GB (2x16GB) 3200Mhz FURY Beast Bla...', 4, 9, '3069.00', 40, 'RAM Kingston DDR4 32GB (2x16GB) 3200Mhz FURY Beast...', '2024-10-16'),
(22, 'Kingston DDR4 8GB 3200Mhz FURY Beast Black', 4, 9, '839.00', 0, 'RAM Kingston DDR4 8GB 3200Mhz FURY Beast Black (KF...', '2024-10-16'),
(23, 'Corsair DDR4 16GB (2x8GB) 3600Mhz Vengeance LPX Bl...', 4, 8, '1849.00', 11, 'RAM Corsair DDR4 16GB (2x8GB) 3600Mhz Vengeance LP...', '2024-10-16'),
(24, 'G.Skill DDR4 16GB (2x8GB) 3200Mhz Ripjaws V', 4, 10, '1340.00', 28, 'RAM G.Skill DDR4 16GB (2x8GB) 3200Mhz Ripjaws V (F...', '2024-10-16'),
(25, 'HDD Seagate BarraCuda 1TB', 5, 18, '2175.00', 22, 'HDD Seagate BarraCuda 1TB 64MB 7200RPM 3...', '2024-10-16'),
(26, 'HDD Seagate BarraCuda 2TB', 5, 18, '2599.00', 22, 'HDD Seagate BarraCuda 2TB 256MB 7200RPM ...', '2024-10-16'),
(27, 'SSD Kingston KC3000 3D NAND TLC 1TB M.2', 6, 9, '4119.00', 28, 'SSD Kingston KC3000 3D NAND TLC 1TB M.2 (2280...', '2024-10-16'),
(28, 'SSD Samsung 970 Evo Plus V-NAND MLC 1TB M.2', 6, 11, '4199.00', 13, 'SSD Samsung 970 Evo Plus V-NAND MLC 1TB M.2 (...', '2024-10-16'),
(29, 'Power Supply Deepcool PF700 700W', 7, 14, '2449.00', 2, 'Power Supply Deepcool PF700 700W (R-PF700D-HA0B-E...', '2024-10-16'),
(30, 'Power Supply Be Quiet! Pure Power 12 M 850W', 7, 16, '5999.00', 7, 'Power Supply Be Quiet! Pure Power 12 M 850W (BN34...', '2024-10-16'),
(31, 'Case MSI MAG FORGE M100R Black', 8, 5, '1999.00', 9, 'Case MSI MAG FORGE M100R without PSU Black', '2024-10-16'),
(32, 'Case NZXT H6 Flow Black', 8, 15, '6299.00', 0, 'Case NZXT H6 Flow without PSU (CC-H61FB-01) Black', '2024-10-16'),
(33, 'Case Deepcool CH780 Tempered Glass', 8, 14, '6999.00', 0, 'Case Deepcool CH780 Tempered Glass without PSU (R-CH7...', '2024-10-16'),
(34, 'Cooler Arctic Freezer 34', 9, 7, '849.00', 15, 'Cooler Arctic Freezer 34 (ACFRE00078A)', '2024-10-16'),
(35, 'Cooler Cooler Master Hyper 212 Black Edition', 9, 3, '1299.00', 10, 'Cooler Cooler Master Hyper 212 Black Edition', '2024-10-16'),
(36, 'Cooler be quiet! Pure Rock 2', 9, 16, '1599.00', 3, 'Cooler be quiet! Pure Rock 2', '2024-10-16');

-- --------------------------------------------------------

--
-- Table structure for table `computer_productcategory`
--

CREATE TABLE `computer_productcategory` (
  `ID` int(11) NOT NULL,
  `category_name` varchar(255) NOT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `computer_productcategory`
--

INSERT INTO `computer_productcategory` (`ID`, `category_name`, `description`) VALUES
(1, 'Processors', 'Product category containing various types of processors'),
(2, 'Graphics Cards', 'Product category containing graphics cards for PC'),
(3, 'Motherboards', 'Product category containing motherboards'),
(4, 'RAM', 'Product category containing RAM'),
(5, 'Hard Drives', 'Product category containing hard drives'),
(6, 'SSD', 'Product category containing solid-state drives'),
(7, 'Power Supply Units', 'Product category containing power supply units'),
(8, 'Cases', 'Product category containing cases'),
(9, 'Cooling Systems', 'Product category containing cooling systems'),
(10, 'Assembly Accessories', 'Product category containing assembly accessories');

-- --------------------------------------------------------

--
-- Table structure for table `mobile_customer`
--

CREATE TABLE `mobile_customer` (
  `ID` int(100) NOT NULL,
  `store_name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `delivery_address` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mobile_customer`
--

INSERT INTO `mobile_customer` (`ID`, `store_name`, `Email`, `phone`, `delivery_address`) VALUES
(1, 'fsdf', 'sdf', '324', 'fssf');

-- --------------------------------------------------------

--
-- Table structure for table `mobile_manufacturer`
--

CREATE TABLE `mobile_manufacturer` (
  `ID` int(11) NOT NULL,
  `manufacturer_name` varchar(255) NOT NULL,
  `country` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mobile_manufacturer`
--

INSERT INTO `mobile_manufacturer` (`ID`, `manufacturer_name`, `country`) VALUES
(2, 'Apple', 'USA'),
(3, 'Samsung', 'South Korea'),
(4, 'Huawei', 'China'),
(5, 'Xiaomi', 'China'),
(6, 'Oppo', 'China'),
(7, 'OnePlus', 'China'),
(8, 'Sony', 'Japan'),
(9, 'LG', 'South Korea'),
(10, 'Nokia', 'Finland'),
(11, 'Motorola', 'USA');

-- --------------------------------------------------------

--
-- Table structure for table `mobile_order`
--

CREATE TABLE `mobile_order` (
  `ID` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `delivery_date` date DEFAULT NULL,
  `items` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mobile_order`
--

INSERT INTO `mobile_order` (`ID`, `customer_id`, `order_date`, `total_amount`, `status`, `delivery_date`, `items`) VALUES
(1, 1, '2025-03-13 11:50:01', '1000.00', 'dsad', '2025-10-10', NULL),
(2, 1, '2025-03-25 10:24:39', '35999.00', 'fsd', '2025-10-10', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `mobile_order_details`
--

CREATE TABLE `mobile_order_details` (
  `ID_Primary` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mobile_order_details`
--

INSERT INTO `mobile_order_details` (`ID_Primary`, `order_id`, `product_id`, `quantity`, `price`) VALUES
(1, 1, 1, 1, '1000.00'),
(2, 2, 2, 1, '35999.00');

-- --------------------------------------------------------

--
-- Table structure for table `mobile_payment`
--

CREATE TABLE `mobile_payment` (
  `ID_Primary` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `payment_method` varchar(50) NOT NULL,
  `payment_amount` decimal(10,2) NOT NULL,
  `payment_date` datetime DEFAULT NULL,
  `payment_status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mobile_payment`
--

INSERT INTO `mobile_payment` (`ID_Primary`, `order_id`, `payment_method`, `payment_amount`, `payment_date`, `payment_status`) VALUES
(1, 1, 'fdsf', '1000.00', '2025-03-13 11:52:58', 'dfsf');

-- --------------------------------------------------------

--
-- Table structure for table `mobile_product`
--

CREATE TABLE `mobile_product` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `manufacturer_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) DEFAULT NULL,
  `description` text,
  `date_added` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mobile_product`
--

INSERT INTO `mobile_product` (`ID`, `name`, `category_id`, `manufacturer_id`, `price`, `stock_quantity`, `description`, `date_added`) VALUES
(2, 'iPhone 14 Pro', 1, 1, '35999.00', 24, 'Apple iPhone 14 Pro smartphone with 6.1-inch Super Retina XDR display, A16 Bionic chip, triple cameras and 5G support.', '2024-03-13'),
(3, 'Samsung Galaxy S23', 1, 2, '29999.00', 40, 'Samsung Galaxy S23 smartphone with 6.1-inch AMOLED display, Snapdragon 8 Gen 2, 50MP cameras and 5G support.', '2024-03-13'),
(4, 'Huawei P50 Pro', 1, 3, '27999.00', 10, 'Huawei P50 Pro smartphone with 6.6-inch OLED display, Kirin 9000, Leica 50MP cameras and 4G support.', '2024-03-13'),
(5, 'Xiaomi 13 Pro', 1, 4, '24999.00', 35, 'Xiaomi 13 Pro smartphone with 6.73-inch AMOLED display, Snapdragon 8 Gen 2, 50MP camera and 5G support.', '2024-03-13'),
(6, 'Oppo Find X5 Pro', 1, 5, '31999.00', 12, 'Oppo Find X5 Pro smartphone with 6.7-inch AMOLED display, Snapdragon 8 Gen 1, 50MP cameras and 5G support.', '2024-03-13'),
(7, 'OnePlus 11', 1, 6, '27999.00', 30, 'OnePlus 11 smartphone with 6.7-inch AMOLED display, Snapdragon 8 Gen 2, 50MP cameras and 5G support.', '2024-03-13'),
(8, 'Sony Xperia 1 IV', 1, 7, '39999.00', 8, 'Sony Xperia 1 IV smartphone with 6.5-inch 4K OLED display, Snapdragon 8 Gen 1, 48MP cameras and 5G support.', '2024-03-13'),
(9, 'Nokia X100', 1, 8, '12999.00', 50, 'Nokia X100 smartphone with 6.67-inch LCD display, Snapdragon 480, 48MP cameras and 5G support.', '2024-03-13'),
(10, 'Motorola Edge 40', 1, 9, '18999.00', 20, 'Motorola Edge 40 smartphone with 6.7-inch AMOLED display, MediaTek Dimensity 8020, 50MP cameras and 5G support.', '2024-03-13'),
(11, 'Xiaomi Mi Band 7', 2, 4, '1699.00', 150, 'Xiaomi Mi Band 7 fitness tracker with 1.62-inch AMOLED display, heart rate monitoring and up to 14-day battery life.', '2024-03-13');

-- --------------------------------------------------------

--
-- Table structure for table `mobile_productcategory`
--

CREATE TABLE `mobile_productcategory` (
  `ID` int(11) NOT NULL,
  `category_name` varchar(255) NOT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mobile_productcategory`
--

INSERT INTO `mobile_productcategory` (`ID`, `category_name`, `description`) VALUES
(2, 'Smartphones', 'Mobile phone category including various smartphone models for everyday use'),
(3, 'Fitness Trackers', 'Category of devices for monitoring physical activity, health and sleep'),
(4, 'Gadgets', 'Category of mobile accessories and various additional devices compatible with mobile phones'),
(5, 'Mobile Accessories', 'Category of accessories for mobile devices: cases, screen protectors, chargers'),
(6, 'Tablets', 'Category of mobile devices with larger screens, ideal for multimedia and work'),
(7, 'Smart Watches', 'Category of watches with smart device functions for tracking health, notifications and other features'),
(8, 'Feature Phones', 'Category of simple mobile phones with buttons for basic needs');

-- --------------------------------------------------------

--
-- Table structure for table `peripheral_customer`
--

CREATE TABLE `peripheral_customer` (
  `ID` int(100) NOT NULL,
  `store_name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `delivery_address` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `peripheral_manufacturer`
--

CREATE TABLE `peripheral_manufacturer` (
  `ID` int(11) NOT NULL,
  `manufacturer_name` varchar(255) NOT NULL,
  `country` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `peripheral_manufacturer`
--

INSERT INTO `peripheral_manufacturer` (`ID`, `manufacturer_name`, `country`) VALUES
(1, 'Logitech', 'Switzerland'),
(2, 'Razer', 'USA'),
(3, 'Corsair', 'USA'),
(4, 'SteelSeries', 'Denmark'),
(5, 'HyperX', 'USA'),
(6, 'Logitech G', 'Switzerland'),
(7, 'Redragon', 'China'),
(8, 'Creative Labs', 'Singapore'),
(9, 'BenQ', 'Taiwan'),
(10, 'Microsoft', 'USA');

-- --------------------------------------------------------

--
-- Table structure for table `peripheral_order`
--

CREATE TABLE `peripheral_order` (
  `ID` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `delivery_date` date DEFAULT NULL,
  `items` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `peripheral_order_details`
--

CREATE TABLE `peripheral_order_details` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `peripheral_payment`
--

CREATE TABLE `peripheral_payment` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `payment_method` varchar(50) NOT NULL,
  `payment_amount` decimal(10,2) NOT NULL,
  `payment_date` datetime DEFAULT NULL,
  `payment_status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `peripheral_product`
--

CREATE TABLE `peripheral_product` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `manufacturer_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) DEFAULT NULL,
  `description` text,
  `date_added` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `peripheral_product`
--

INSERT INTO `peripheral_product` (`ID`, `name`, `category_id`, `manufacturer_id`, `price`, `stock_quantity`, `description`, `date_added`) VALUES
(1, 'Logitech MX Master 3', 1, 1, '2999.00', 50, 'Logitech MX Master 3 mouse with ergonomic design, Bluetooth support and wireless charging', '2024-03-13'),
(2, 'Razer DeathAdder V2', 1, 2, '2499.00', 75, 'Razer DeathAdder V2 gaming mouse with precise sensor and adjustable lighting', '2024-03-13'),
(3, 'Corsair K95 RGB Platinum', 2, 3, '5999.00', 30, 'Corsair K95 RGB mechanical keyboard with backlighting and extra keys for gamers', '2024-03-13'),
(4, 'SteelSeries Arctis 7', 3, 4, '4499.00', 40, 'SteelSeries Arctis 7 wireless headset with DTS Headphone:X 2.0 support', '2024-03-13'),
(5, 'Blue Yeti X', 4, 5, '6299.00', 25, 'Blue Yeti X microphone with 4-capsule technology for professional recording and streaming', '2024-03-13'),
(6, 'Creative Pebble 2.0', 5, 6, '799.00', 100, 'Creative Pebble 2.0 compact speakers with USB connection and good sound quality', '2024-03-13'),
(7, 'Xbox Wireless Controller', 6, 7, '1899.00', 60, 'Xbox Wireless Controller gamepad for PC and Xbox', '2024-03-13'),
(8, 'Logitech G Pro X', 7, 1, '3199.00', 45, 'Logitech G Pro X trackpad with USB connection for precise control', '2024-03-13'),
(9, 'Logitech Brio 4K', 8, 1, '8499.00', 15, 'Logitech Brio 4K webcam with high definition support and automatic light correction', '2024-03-13'),
(10, 'Targus CityLite Backpack', 9, 8, '1999.00', 55, 'Targus CityLite laptop bag with accessory compartments and water-repellent coating', '2024-03-13');

-- --------------------------------------------------------

--
-- Table structure for table `peripheral_productcategory`
--

CREATE TABLE `peripheral_productcategory` (
  `ID` int(11) NOT NULL,
  `category_name` varchar(255) NOT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `peripheral_productcategory`
--

INSERT INTO `peripheral_productcategory` (`ID`, `category_name`, `description`) VALUES
(1, 'Mice', 'Product category containing various types of computer mice for work and gaming'),
(2, 'Keyboards', 'Product category containing keyboards for computers, including mechanical and membrane'),
(3, 'Headphones', 'Product category containing headphones for computers and mobile devices'),
(4, 'Microphones', 'Product category containing microphones for audio recording and video calls'),
(5, 'Speakers', 'Product category containing computer speakers for audio playback'),
(6, 'Game Controllers', 'Product category containing joysticks and gamepads for gaming'),
(7, 'Trackpads', 'Product category containing trackpads and touchpads for computers'),
(8, 'Webcams', 'Product category containing webcams for video calls and video recording'),
(9, 'Laptop Bags', 'Product category containing bags and backpacks for transporting laptops'),
(10, 'Gaming Mice', 'Product category containing gaming mice with additional features and settings');

-- --------------------------------------------------------

--
-- Table structure for table `television_customer`
--

CREATE TABLE `television_customer` (
  `ID` int(100) NOT NULL,
  `store_name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `delivery_address` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `television_customer`
--

INSERT INTO `television_customer` (`ID`, `store_name`, `Email`, `phone`, `delivery_address`) VALUES
(1, 'fsdf', 'dsf', '123', 'fsf');

-- --------------------------------------------------------

--
-- Table structure for table `television_manufacturer`
--

CREATE TABLE `television_manufacturer` (
  `ID` int(11) NOT NULL,
  `manufacturer_name` varchar(255) NOT NULL,
  `country` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `television_manufacturer`
--

INSERT INTO `television_manufacturer` (`ID`, `manufacturer_name`, `country`) VALUES
(2, 'Samsung', 'South Korea'),
(3, 'LG', 'South Korea'),
(4, 'Sony', 'Japan'),
(5, 'Panasonic', 'Japan'),
(6, 'Hisense', 'China'),
(7, 'TCL', 'China'),
(8, 'Sharp', 'Japan'),
(9, 'Vizio', 'USA'),
(10, 'Philips', 'Netherlands'),
(11, 'Skyworth', 'China');

-- --------------------------------------------------------

--
-- Table structure for table `television_order`
--

CREATE TABLE `television_order` (
  `ID` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `delivery_date` date DEFAULT NULL,
  `items` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `television_order`
--

INSERT INTO `television_order` (`ID`, `customer_id`, `order_date`, `total_amount`, `status`, `delivery_date`, `items`) VALUES
(1, 1, '2025-03-13 12:03:27', '12435.00', 'dfs', '2025-10-10', NULL),
(2, 1, '2025-04-18 15:41:16', '79999.00', 'dsa', '2025-04-18', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `television_order_details`
--

CREATE TABLE `television_order_details` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `television_order_details`
--

INSERT INTO `television_order_details` (`ID`, `order_id`, `product_id`, `quantity`, `price`) VALUES
(1, 1, 1, 1, '12435.00'),
(2, 2, 3, 1, '79999.00');

-- --------------------------------------------------------

--
-- Table structure for table `television_payment`
--

CREATE TABLE `television_payment` (
  `ID` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `payment_method` varchar(50) NOT NULL,
  `payment_amount` decimal(10,2) NOT NULL,
  `payment_date` datetime DEFAULT NULL,
  `payment_status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `television_payment`
--

INSERT INTO `television_payment` (`ID`, `order_id`, `payment_method`, `payment_amount`, `payment_date`, `payment_status`) VALUES
(1, 1, 'fsdf', '12435.00', '2025-03-13 12:03:57', 'sdf');

-- --------------------------------------------------------

--
-- Table structure for table `television_product`
--

CREATE TABLE `television_product` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `manufacturer_id` int(11) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) DEFAULT NULL,
  `description` text,
  `date_added` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `television_product`
--

INSERT INTO `television_product` (`ID`, `name`, `category_id`, `manufacturer_id`, `price`, `stock_quantity`, `description`, `date_added`) VALUES
(2, 'Samsung 55\" QLED 4K TV', 3, 1, '24999.00', 15, '55-inch QLED TV from Samsung with 4K resolution, Smart TV and HDR support.', '2024-10-01'),
(3, 'LG 65\" OLED 8K TV', 2, 2, '79999.00', 9, '65-inch OLED TV from LG with 8K resolution for incredible image quality.', '2024-10-05'),
(4, 'Sony 50\" LED 4K TV', 1, 3, '14999.00', 20, '50-inch LED TV from Sony with 4K support and Smart TV feature.', '2024-10-10'),
(5, 'Samsung 75\" LED Smart TV', 1, 1, '28999.00', 8, '75-inch LED TV from Samsung with 4K resolution and Smart TV features.', '2024-10-12'),
(6, 'LG 55\" 4K OLED TV', 2, 2, '59999.00', 12, '55-inch OLED TV from LG with 4K resolution and HDR support.', '2024-10-15'),
(7, 'TCL 40\" LED TV', 1, 4, '7499.00', 25, '40-inch LED TV from TCL with Full HD resolution, suitable for small rooms.', '2024-10-17'),
(8, 'Hisense 65\" QLED 4K TV', 3, 5, '21999.00', 14, '65-inch QLED TV from Hisense with 4K support, Smart TV and Dolby Vision.', '2024-10-20'),
(9, 'Philips 55\" 4K Ambilight TV', 3, 6, '17999.00', 9, '55-inch 4K TV from Philips with Ambilight technology for enhanced viewing.', '2024-10-25'),
(10, 'Vizio 70\" 4K Smart TV', 1, 7, '19999.00', 18, '70-inch TV from Vizio with 4K resolution and Smart TV feature.', '2024-10-28'),
(11, 'Sharp 60\" 8K Smart TV', 4, 8, '69999.00', 5, '60-inch 8K TV from Sharp with Smart TV support and high resolution.', '2024-10-30');

-- --------------------------------------------------------

--
-- Table structure for table `television_productcategory`
--

CREATE TABLE `television_productcategory` (
  `ID` int(11) NOT NULL,
  `category_name` varchar(255) NOT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `television_productcategory`
--

INSERT INTO `television_productcategory` (`ID`, `category_name`, `description`) VALUES
(2, 'LED TV', 'TVs with LED backlighting, popular for energy efficiency and bright image.'),
(3, 'OLED TV', 'TVs with organic LEDs providing exceptional image quality with deep black tones.'),
(4, 'QLED TV', 'TVs with quantum dots for improved brightness and colors.'),
(5, '4K TV', 'TVs with 4K resolution for sharper image and higher detail.'),
(6, '8K TV', 'TVs with 8K resolution for extremely high image quality and detail.'),
(7, 'Smart TV', 'TVs that support internet connection and apps for streaming video and entertainment.'),
(8, 'Curved TV', 'TVs with a curved screen for greater immersion in viewing.'),
(9, 'Plasma TV', 'Plasma display-based TVs providing rich color image but less energy efficient.'),
(10, 'Mini LED TV', 'TVs with mini-LED backlighting for even better contrast and brightness.'),
(11, 'Projection TV', 'TVs that use a projector for large-screen viewing.');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Department` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Username`, `PasswordHash`, `Department`) VALUES
(1, 'admin', '$2a$12$lNfIjOru7AkpnYbdk04RIOCVevxb6H2vihJCk7luGioDv2xNCTqTm', 'admin'),
(2, 'computer_manager', '$2a$12$K3S6fBOxBSbLZ15aNmlFU.aGLxwAzuYE4joNzV.DSNIBIiOjaUE0a', 'computer'),
(3, 'mobile_manager', '$2a$12$XfzqFA/nzx9ygEPcv8p3vOevIA2fXEn9O2WjbCNnDEgiAhQIktP66', 'mobile'),
(4, 'television_manager', '$2a$12$T417Ufy2uTY/NMZFYjBHRO3hggkrYDh8xQXa4tFvpzeYthsIgkYdS', 'television'),
(5, 'peripheral_manager', '$2a$12$G2MNqEnCvADU12jvPeyHtuU6SJ5yD6ENbcSNFLWFMzDXRraMEAVr2', 'peripheral'),
(6, 'audio_manager', '$2a$12$hCQ6lIjm3K2IUFK0yxV8HueA9TPLvrBQtm3jnuuZygK7F8usgwzYq', 'audio');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin_customer`
--
ALTER TABLE `admin_customer`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `admin_manufacturer`
--
ALTER TABLE `admin_manufacturer`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `manufacturer_name` (`manufacturer_name`);

--
-- Indexes for table `admin_order`
--
ALTER TABLE `admin_order`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `idx_order_department` (`order_id`,`department`);

--
-- Indexes for table `admin_payment`
--
ALTER TABLE `admin_payment`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `fk_admin_payment_order` (`order_id`,`department`);

--
-- Indexes for table `admin_product`
--
ALTER TABLE `admin_product`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `name` (`name`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `manufacturer_id` (`manufacturer_id`);

--
-- Indexes for table `admin_productcategory`
--
ALTER TABLE `admin_productcategory`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `category_name` (`category_name`);

--
-- Indexes for table `audio_customer`
--
ALTER TABLE `audio_customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `audio_manufacturer`
--
ALTER TABLE `audio_manufacturer`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_manufacturer_name` (`manufacturer_name`);

--
-- Indexes for table `audio_order`
--
ALTER TABLE `audio_order`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_customer_id` (`customer_id`);

--
-- Indexes for table `audio_order_details`
--
ALTER TABLE `audio_order_details`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_order_id` (`order_id`),
  ADD KEY `idx_product_id` (`product_id`);

--
-- Indexes for table `audio_payment`
--
ALTER TABLE `audio_payment`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_order_id` (`order_id`);

--
-- Indexes for table `audio_product`
--
ALTER TABLE `audio_product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_name` (`name`),
  ADD KEY `idx_category_id` (`category_id`),
  ADD KEY `idx_manufacturer_id` (`manufacturer_id`);

--
-- Indexes for table `audio_productcategory`
--
ALTER TABLE `audio_productcategory`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_category_name` (`category_name`);

--
-- Indexes for table `computer_customer`
--
ALTER TABLE `computer_customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `computer_manufacturer`
--
ALTER TABLE `computer_manufacturer`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `manufacturer_name` (`manufacturer_name`);

--
-- Indexes for table `computer_order`
--
ALTER TABLE `computer_order`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `customer_id` (`customer_id`);

--
-- Indexes for table `computer_order_details`
--
ALTER TABLE `computer_order_details`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `order_id` (`order_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `computer_payment`
--
ALTER TABLE `computer_payment`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `order_id` (`order_id`);

--
-- Indexes for table `computer_product`
--
ALTER TABLE `computer_product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `name` (`name`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `manufacturer_id` (`manufacturer_id`);

--
-- Indexes for table `computer_productcategory`
--
ALTER TABLE `computer_productcategory`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `category_name` (`category_name`);

--
-- Indexes for table `mobile_customer`
--
ALTER TABLE `mobile_customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `mobile_manufacturer`
--
ALTER TABLE `mobile_manufacturer`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_manufacturer_name` (`manufacturer_name`);

--
-- Indexes for table `mobile_order`
--
ALTER TABLE `mobile_order`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `customer_id` (`customer_id`);

--
-- Indexes for table `mobile_order_details`
--
ALTER TABLE `mobile_order_details`
  ADD PRIMARY KEY (`ID_Primary`),
  ADD KEY `idx_order_id` (`order_id`),
  ADD KEY `idx_product_id` (`product_id`);

--
-- Indexes for table `mobile_payment`
--
ALTER TABLE `mobile_payment`
  ADD PRIMARY KEY (`ID_Primary`),
  ADD KEY `idx_order_id` (`order_id`);

--
-- Indexes for table `mobile_product`
--
ALTER TABLE `mobile_product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_name` (`name`),
  ADD KEY `idx_category_id` (`category_id`),
  ADD KEY `idx_manufacturer_id` (`manufacturer_id`);

--
-- Indexes for table `mobile_productcategory`
--
ALTER TABLE `mobile_productcategory`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_category_name` (`category_name`);

--
-- Indexes for table `peripheral_customer`
--
ALTER TABLE `peripheral_customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `peripheral_manufacturer`
--
ALTER TABLE `peripheral_manufacturer`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_manufacturer_name` (`manufacturer_name`);

--
-- Indexes for table `peripheral_order`
--
ALTER TABLE `peripheral_order`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_customer_id` (`customer_id`);

--
-- Indexes for table `peripheral_order_details`
--
ALTER TABLE `peripheral_order_details`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_order_id` (`order_id`),
  ADD KEY `idx_product_id` (`product_id`);

--
-- Indexes for table `peripheral_payment`
--
ALTER TABLE `peripheral_payment`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_order_id` (`order_id`);

--
-- Indexes for table `peripheral_product`
--
ALTER TABLE `peripheral_product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_name` (`name`),
  ADD KEY `idx_category_id` (`category_id`),
  ADD KEY `idx_manufacturer_id` (`manufacturer_id`);

--
-- Indexes for table `peripheral_productcategory`
--
ALTER TABLE `peripheral_productcategory`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_category_name` (`category_name`);

--
-- Indexes for table `television_customer`
--
ALTER TABLE `television_customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `television_manufacturer`
--
ALTER TABLE `television_manufacturer`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_manufacturer_name` (`manufacturer_name`);

--
-- Indexes for table `television_order`
--
ALTER TABLE `television_order`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_customer_id` (`customer_id`);

--
-- Indexes for table `television_order_details`
--
ALTER TABLE `television_order_details`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_order_id` (`order_id`),
  ADD KEY `idx_product_id` (`product_id`);

--
-- Indexes for table `television_payment`
--
ALTER TABLE `television_payment`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_order_id` (`order_id`);

--
-- Indexes for table `television_product`
--
ALTER TABLE `television_product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_name` (`name`),
  ADD KEY `idx_category_id` (`category_id`),
  ADD KEY `idx_manufacturer_id` (`manufacturer_id`);

--
-- Indexes for table `television_productcategory`
--
ALTER TABLE `television_productcategory`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `idx_category_name` (`category_name`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin_customer`
--
ALTER TABLE `admin_customer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `admin_manufacturer`
--
ALTER TABLE `admin_manufacturer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `admin_order`
--
ALTER TABLE `admin_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `admin_payment`
--
ALTER TABLE `admin_payment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `admin_product`
--
ALTER TABLE `admin_product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `admin_productcategory`
--
ALTER TABLE `admin_productcategory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `audio_customer`
--
ALTER TABLE `audio_customer`
  MODIFY `ID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `audio_manufacturer`
--
ALTER TABLE `audio_manufacturer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `audio_order`
--
ALTER TABLE `audio_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `audio_order_details`
--
ALTER TABLE `audio_order_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `audio_payment`
--
ALTER TABLE `audio_payment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `audio_product`
--
ALTER TABLE `audio_product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `audio_productcategory`
--
ALTER TABLE `audio_productcategory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `computer_customer`
--
ALTER TABLE `computer_customer`
  MODIFY `ID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `computer_manufacturer`
--
ALTER TABLE `computer_manufacturer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `computer_order`
--
ALTER TABLE `computer_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `computer_order_details`
--
ALTER TABLE `computer_order_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `computer_payment`
--
ALTER TABLE `computer_payment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `computer_product`
--
ALTER TABLE `computer_product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `computer_productcategory`
--
ALTER TABLE `computer_productcategory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `mobile_customer`
--
ALTER TABLE `mobile_customer`
  MODIFY `ID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `mobile_manufacturer`
--
ALTER TABLE `mobile_manufacturer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `mobile_order`
--
ALTER TABLE `mobile_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `mobile_order_details`
--
ALTER TABLE `mobile_order_details`
  MODIFY `ID_Primary` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `mobile_payment`
--
ALTER TABLE `mobile_payment`
  MODIFY `ID_Primary` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `mobile_product`
--
ALTER TABLE `mobile_product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `mobile_productcategory`
--
ALTER TABLE `mobile_productcategory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `peripheral_customer`
--
ALTER TABLE `peripheral_customer`
  MODIFY `ID` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `peripheral_manufacturer`
--
ALTER TABLE `peripheral_manufacturer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `peripheral_order`
--
ALTER TABLE `peripheral_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `peripheral_order_details`
--
ALTER TABLE `peripheral_order_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `peripheral_payment`
--
ALTER TABLE `peripheral_payment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `peripheral_product`
--
ALTER TABLE `peripheral_product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `peripheral_productcategory`
--
ALTER TABLE `peripheral_productcategory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `television_customer`
--
ALTER TABLE `television_customer`
  MODIFY `ID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `television_manufacturer`
--
ALTER TABLE `television_manufacturer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `television_order`
--
ALTER TABLE `television_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `television_order_details`
--
ALTER TABLE `television_order_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `television_payment`
--
ALTER TABLE `television_payment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `television_product`
--
ALTER TABLE `television_product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `television_productcategory`
--
ALTER TABLE `television_productcategory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `admin_payment`
--
ALTER TABLE `admin_payment`
  ADD CONSTRAINT `fk_admin_payment_order` FOREIGN KEY (`order_id`,`department`) REFERENCES `admin_order` (`order_id`, `department`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `admin_product`
--
ALTER TABLE `admin_product`
  ADD CONSTRAINT `admin_product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `admin_productcategory` (`ID`),
  ADD CONSTRAINT `admin_product_ibfk_2` FOREIGN KEY (`manufacturer_id`) REFERENCES `admin_manufacturer` (`ID`);

--
-- Constraints for table `audio_order`
--
ALTER TABLE `audio_order`
  ADD CONSTRAINT `fk_audio_customer` FOREIGN KEY (`customer_id`) REFERENCES `admin_customer` (`ID`);

--
-- Constraints for table `computer_order`
--
ALTER TABLE `computer_order`
  ADD CONSTRAINT `fk_customer_id_admin` FOREIGN KEY (`customer_id`) REFERENCES `admin_customer` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `computer_order_details`
--
ALTER TABLE `computer_order_details`
  ADD CONSTRAINT `computer_order_details_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `computer_order` (`ID`),
  ADD CONSTRAINT `computer_order_details_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `computer_product` (`ID`);

--
-- Constraints for table `computer_product`
--
ALTER TABLE `computer_product`
  ADD CONSTRAINT `FK_manufacturer_id` FOREIGN KEY (`manufacturer_id`) REFERENCES `computer_manufacturer` (`ID`),
  ADD CONSTRAINT `FK_category_id` FOREIGN KEY (`category_id`) REFERENCES `computer_productcategory` (`ID`);

--
-- Constraints for table `mobile_order`
--
ALTER TABLE `mobile_order`
  ADD CONSTRAINT `fk_mobile_customer` FOREIGN KEY (`customer_id`) REFERENCES `admin_customer` (`ID`);

--
-- Constraints for table `peripheral_order`
--
ALTER TABLE `peripheral_order`
  ADD CONSTRAINT `fk_peripheral_customer` FOREIGN KEY (`customer_id`) REFERENCES `admin_customer` (`ID`);

--
-- Constraints for table `television_order`
--
ALTER TABLE `television_order`
  ADD CONSTRAINT `fk_television_customer` FOREIGN KEY (`customer_id`) REFERENCES `admin_customer` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
