import json
import logging
import os

logging.basicConfig(level=logging.INFO, format='%(message)s')

def sort_json_file(input_file, output_file):
    try:
        with open(input_file, 'r') as infile:
            data = json.load(infile)

        sorted_data = json.dumps(data, sort_keys=True, indent=4)

        with open(output_file, 'w') as outfile:
            outfile.write(sorted_data)

        logging.info(f"Sorted JSON file saved as: {output_file}")

    except Exception as e:
        logging.error(f"Error sorting JSON file {input_file}: {e}")

def compare_json_files(file1, file2):
    try:
        with open(file1, 'r') as f1, open(file2, 'r') as f2:
            data1 = json.load(f1)
            data2 = json.load(f2)

        # Compare JSON data
        if data1 == data2:
            logging.info(f"The JSON files are identical: {file1} {file2}")
        else:
            logging.info(f"The JSON files are different: {file1} {file2}")

    except Exception as e:
        logging.error(f"Error comparing JSON files {file1} and {file2}: {e}")

def main():
    input_files = [
        "./occurence-tables/01-solution.json",
        "./occurence-tables/02-solution.json",
        "./occurence-tables/03-solution.json",
        "./occurence-tables/04-solution.json",
        "./occurence-tables/05-solution.json"
    ]

    sorted_files = []
    for file in input_files:
        sorted_file = file.replace(".json", "-sorted.json")
        sort_json_file(file, sorted_file)
        sorted_files.append(sorted_file)

    for i in range(len(sorted_files)):
        for j in range(i + 1, len(sorted_files)):
            compare_json_files(sorted_files[i], sorted_files[j])

main()